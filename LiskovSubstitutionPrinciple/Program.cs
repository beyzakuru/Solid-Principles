#region Kodun çalıştırıldığı kısım

Renault renault = new Renault();
Nissan nissan = new Nissan();

renault.SendInfoDriverSms(new DriveInfo
{
    Telephone = "455544"
});

nissan.SendInfoDriverEMail(new DriveInfo
{
    EmailAdress = "fgbjkdşkjf",
    Telephone="45352"
});
nissan.SendInfoDriverSms(new DriveInfo
{
    Telephone = "4356"
});

#endregion


#region Renault
public class Renault : BaseCar, ISmsSendable
{
    public void SendInfoDriverSms(DriveInfo sms)
    {
        Console.WriteLine("Sms gönderildi.");
    }
}
#endregion

#region Nissan
public class Nissan : BaseCar, ISmsSendable, IEMailSendable
{
    public void SendInfoDriverEMail(DriveInfo mail)
    {
       Console.WriteLine("Email gönderildi.");
    }

    public void SendInfoDriverSms(DriveInfo sms)
    {
        Console.WriteLine("Sms gönderildi.");
    }
}
#endregion


#region BaseCar Araba Class'ının OLuşturulması.
// Birden fazla araba kullanımı durumunda tekrar aynı metotları yazmamak adına soyut bir sınıf oluşturduk.

public abstract class BaseCar
{
    public double RoadKm { get; set; }

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

    
    //public void SendInfoDriverSms(DriveInfo driver)
    //{
    //    if (!String.IsNullOrEmpty(driver.Telephone))
    //    {
    //        SendSms();
    //    }
    //}

    //public void SendInfoDriverMail(DriveInfo driver)
    //{
    //    // Buradaki kısıt anlık çözüm önerisi sunar. Ancak doğru bir yaklaşım değildir. Bu sefer de
    //    // Open/Closed prensibi ile ters düşmektedir.

    //    if (!String.IsNullOrEmpty(driver.EmailAdress) && (!(this is Renault)))
    //    {
    //        SendMail();
    //    }
    //}

}

public class DriveInfo
{
    public string EmailAdress { get; set; }
    public string Telephone { get; set; }
}


#region Interface tanımlamaları

public interface ISmsSendable
{
    void SendInfoDriverSms(DriveInfo sms);
}

public interface IEMailSendable
{
    void SendInfoDriverEMail(DriveInfo mail);
}
#endregion

#endregion
