using System.Security.Cryptography;
using System.Text;
using subscriblySystem.Domain.Entities;
using subscriblySystem.Domain.Enum;
using SubscriblySystems.Aplication.Dto;
using SubscriblySystems.Aplication.Dto.UserDto;
using SubscriblySystems.Aplication.Extension;
using SubscriblySystems.Aplication.Repositories.BoardRepositories;
using SubscriblySystems.Aplication.Repositories.UserRepositories;

namespace SubscriblySystems.Aplication.Services.UserService;


// UserSercie ihtiyaci olan repositoryleri paramatere olarak constructordan aliyor. DI
public class UserService(IUserWriteRepository userWrite, IUserReadRepository userRead, IBoardWriteRepository boradWrite)
{
    private const string BOARD_NAME = "First Board";
    private const string BOARD_DESC = "Welcome to your first board";
    
    // dto, disardan gelene veriyi srvis katmanina tasimak icin olusturulan bir
    // tasarim desenidir. boylece entity'yi dis dunyaya acmadan sadece gerekli alanlari kullanmis oluruz
    public async Task<bool> CreateUser(CreateUserDto createUserDto)
    {
        //Kullanıcı oluşacak
        var User = await userWrite.AddAsync(new User
        {
            IsActive = true,
            UserName = createUserDto.UserName,
            UserSurname = createUserDto.UserSurname,
            Email = createUserDto.UserSurname,
            PasswordHash = createUserDto.Password.ComputeSha256Hash(),
            PhoneNumber = createUserDto.PhoneNumber,
            ProfileImage = createUserDto.ProfileImage,
        });

        var userResult = await userWrite.SaveAsync();
        
        if (!User)
            throw new Exception("Kullanıcı oluşturulurken hata meydana geldi");
        
        //az önce eklediğimiz user getirildi
        var getUser = await userRead.GetSingleAsync(x => x.Email == createUserDto.Email);

        //Kullanıcıya ait bir board oluşacak
        var board = await boradWrite.AddAsync(new Board
        {
            IsActive = true,
            BoardName = BOARD_NAME,
            description =BOARD_DESC ,
            BoardType = BoardTypeEnum.Home,
            Users = new List<User>
            {
                getUser
            }
        });
        
        var boardResult = await boradWrite.SaveAsync();
        
        if (!board)
            throw new Exception("Tablo oluşturulurken hata meydana geldi");
        
        return true;

    }

    public async Task<bool> DeleteUser(DeleteUserDto deleteUser)
    {
        var user = await userRead.GetByIdAsync(deleteUser.Id); // veritabaninda boyle bir kullancici var mi
        if(user == null )
            return false;
            
        // id'ye gore kullanciiyi sil
            var deleteResult = await userWrite.DeleteAsync(user.Id);
            if (!deleteResult)
            {
                return false; // TODO: throw firlatacak
            }
            
            var saveResult = await userWrite.SaveAsync();
            return saveResult > 0; // SaveAsync basariliysa true dondur
    }

    public async Task<bool> UpdateUser(UpdateUserDto updateUserDto, string id)
    {
        //kulanici var mi
        var userId = Guid.Parse(id);
        var user = await userRead.GetByIdAsync(userId);
        if (user == null)
            throw new Exception("Kullanıcı bulunamadi");
        
        // kullanici varsa guncelle
            user.UserName = updateUserDto.UserName;
            user.UserSurname = updateUserDto.UserSurname;
            user.Email = updateUserDto.Email;
            user.PasswordHash = updateUserDto.Password.ComputeSha256Hash();
            user.PhoneNumber = updateUserDto.PhoneNumber;
            user.ProfileImage = updateUserDto.ProfileImage;
        
        // guncellenen kullaniciyi repository'ye gonder
        var updateResult = await userWrite.UpdateAsync(user);
        
        // kaydet
        var saveResult = await userWrite.SaveAsync();
        return saveResult > 0; // true ise basarili
    }

    // kullaniciyi farkli sekillerde getir
    public async Task<User> GetUserById(Guid userId) => await userRead.GetByIdAsync(userId);
    public async Task<User> GetUserByEmail(string email) => await userRead.GetSingleAsync(x => x.Email == email);
    public async Task<User> GetUserByPhone(string phoneNumber) => await userRead.GetSingleAsync(x => x.PhoneNumber == phoneNumber);
    
    
    // sifre degitirme
    public async Task<bool> ChangePassword(Guid userId, string newPassword)
    {
        var user = await userRead.GetByIdAsync(userId); // kullaniciyi getir
        if (user == null)
            return false;

        user.PasswordHash = newPassword.ComputeSha256Hash(); // yeni sifreyi hashle ve guncelle
        var updateResult = userWrite.UpdateAsync(user);
        var saveResult = await userWrite.SaveAsync();
        return  saveResult > 0; 

    }
    public async Task<bool> ValidateUser(Guid userId, string password, string email, string phoneNumber)
    {
        var user = await userRead.GetByIdAsync(userId);
        if (user == null) return false;

        return user.Email == email
               && user.PasswordHash == password.ComputeSha256Hash()
               && user.PhoneNumber == phoneNumber;
    }
    
  
    
    /* 
     * kullanici ile birlikte default olarak bir tane de pano olusacak +
     * Panoya erişim → sadece pano sahibi + pano üyeleri.
       Fatura ödeme → sadece atanmış kişi veya pano sahibi.
       Pano sahibi, hangi kullanıcıların hangi işlemleri yapabileceğini yönetebilmeli (rol bazlı kontrol gibi).
     * bir panoya ait farkli faturalari o panoda bulunan farkli kisiler odeyebilcek
     * yani bir panodaki 2 faturanin birini pano sahibi digerini panodaki diger kisi odeyebilecek ve
     * bu kimin hangi faturayi odeyecegi atamasini pano sahibi yapabilecek
     * kimse dahil olmadigi pano disindaki panolari goruntuleyemeyecek
     * faturayi kimin odeycegi atandiktan sonra diger kisi o faturayi pano sahibi veya odeyecek kisi degilse odeyemeyecek
     * Kullanıcının gelir panoları gibi özel bilgilerini sadece kendisi görebilmeli.
     * Ödemelere ait detaylar sadece ilgili kişilerce görüntülenmeli.
     * Kullanıcılar sadece kendi görebilecekleri panoları listelesin.
     * Bir fatura ödeme ataması yapıldığında ilgili kişiye e-posta veya uygulama içi bildirim gitsin
     */
}