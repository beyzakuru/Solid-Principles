#region Kodun çalıştırıldığı kısım

Renault renault = new Renault();

#region Parametre Gönderimi (Single Responsibilty Uymayan Metoda) 
renault.SendInfoDriver(new DriveInfo
{
    EmailAdress = "beyza@gmail.com",
    Telephone = "123123123"
});
#endregion

#region Parametre Gönderimi (Single Responsibilty Uyan Metoda)
renault.SendInfoDriverMail(new DriveInfo
{
    EmailAdress = "beyza@gmail.com"
});
#endregion

#endregion

#region Birinci Arabanın Class'ının OLuşturulması

public class Renault
{
    public int RoadKm { get; set; }

    public void Go()
    {
        Console.WriteLine("Araba ilerliyor.");
    }

    public void Stop()
    {
        Console.WriteLine("Araba durdu.");
    }

    public void SendMail()
    {
        Console.WriteLine("Mail gönderildi.");
    }

    public void SendSms()
    {
        Console.WriteLine("SMS Gönderildi.");
    }

    // Sürücü bilgileri alınarak eğer email adresi null ya da boş değilse SendMail metodunu çalıştıracağız.Telefon değeri boş ya da null değilse SendSms metodunu çalıştıracağız.

    // Bir metot içerisinde birden fazla işlem yapılmaması gerektiğini gösteren bir metot yazalım. 

    public void SendInfoDriver(DriveInfo driver)
    {
        if (!String.IsNullOrEmpty(driver.EmailAdress))
        {
            SendMail();
        }
        if (!String.IsNullOrEmpty(driver.Telephone))
        {
            SendSms();
        }
    }

    // Yukarıdaki metotta sadece tek bir kanal ile kullanıcının kendine bilgilendirme gelmesini istemesi durumunda iki kanaldan da bilgilendirme yapılmaktadır. 
    // Dolayısıyla single responsibility prensibine uymasını sağlamak amacıyla ayırma işlemi gerçekleştirmemiz gerekmektedir. Aşağıdaki metotta bunu sağlayacağız.

    #region Single Responsibility İşlemleri İçin Yapılan Alan
    public void SendInfoDriverSms(DriveInfo driver)
    {
        if (!String.IsNullOrEmpty(driver.Telephone))
        {
            SendSms();
        }
    }
    
    public void SendInfoDriverMail(DriveInfo driver)
    {
        if (!String.IsNullOrEmpty(driver.EmailAdress))
        {
            SendMail();
        }
    }
    #endregion

}

public class DriveInfo
{
    public string EmailAdress { get; set; }
    public string Telephone { get; set; }
}

#endregion