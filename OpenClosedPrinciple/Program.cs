#region Kodun çalıştırıldığı kısım

FuelCostCalculator calculator = new FuelCostCalculator();

var cost = calculator.Calculate(new Renault());
Console.WriteLine($"Toplam harcanan para: {cost}");
Console.ReadLine();

#endregion


#region Renault
public class Renault : BaseCar
{
    
    public override double GetCostPerKM()
    {
        return 5.6;
    }
}
#endregion

#region Nissan
public class Nissan : BaseCar
{
    public override double GetCostPerKM()
    {
        return 3.5;
    }
}
#endregion

#region Arabaların yakıt giderlerini hesaplayan bir class
public class FuelCostCalculator
{
    public double Calculate(BaseCar car)
    {
        #region Open/Closed uymayan yapı
        // Reanult ve Nissan'ın yakıt masrafları ayrı olabilir. Ancak her defasında farklı araba modelleri eklendiğinde tekrardan bir if bloğu eklemek doğru bir yaklaşım değildir.


        //if (car is Nissan)
        //    return car.RoadKm * 5.6;
        //else if (car is Renault)
        //    return car.RoadKm * 3.5;
        //else
        //    return car.RoadKm * 10.5;
        #endregion

        #region Open/Closed uyan yapı
        return car.RoadKm * car.GetCostPerKM();
        #endregion
    }
}
#endregion

#region BaseCar Araba Class'ının OLuşturulması.
// Birden fazla araba kullanımı durumunda tekrar aynı metotları yazmamak adına soyut bir sınıf oluşturduk.

public abstract class BaseCar
{
    public double RoadKm { get; set; }

    public abstract double GetCostPerKM();

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

    #region kaldırılabilir sonda kontrol et
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
