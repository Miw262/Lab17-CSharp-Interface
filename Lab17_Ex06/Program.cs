using System;

interface IRemoteControl
{
    void TurnOn();  // ✅ ลบ public ออก
    void TurnOff();
    void ChannelUp();
    void ChannelDown();
}

abstract class PowerAppliance
{
    public bool PowerStatus;
    public int Wattage;
}

// ✅ แก้ไขให้สืบทอด IRemoteControl
class Television : PowerAppliance, IRemoteControl
{
    public int Channel { get; set; }

    public virtual void TurnOn() { Console.WriteLine("TV Turn on"); PowerStatus = true; }
    public virtual void TurnOff() { Console.WriteLine("TV Turn off"); PowerStatus = false; }
    public virtual void ChannelUp() { Console.WriteLine("TV Channel up"); }
    public virtual void ChannelDown() { Console.WriteLine("TV Channel down"); }
}

// ✅ แก้ไขให้สืบทอด IRemoteControl
class Lamp : PowerAppliance, IRemoteControl
{
    public virtual void TurnOn() { Console.WriteLine("Lamp Turn on"); PowerStatus = true; }
    public virtual void TurnOff() { Console.WriteLine("Lamp Turn off"); PowerStatus = false; }
    public virtual void ChannelUp() { Console.WriteLine("Lamp cannot change channel"); }
    public virtual void ChannelDown() { Console.WriteLine("Lamp cannot change channel"); }
}

class SonyTV : Television
{
    public override void TurnOn() { Console.WriteLine("Sony TV Turn on"); PowerStatus = true; }
    public override void TurnOff() { Console.WriteLine("Sony TV Turn off"); PowerStatus = false; }
}

class DesktopLamp : Lamp
{
    public override void TurnOn() { Console.WriteLine("Desktop Lamp Turn on"); PowerStatus = true; }
    public override void TurnOff() { Console.WriteLine("Desktop Lamp Turn off"); PowerStatus = false; }
}

class Program
{
    static void Main()
    {
        // ✅ ใช้ IRemoteControl เป็นประเภทตัวแปรเพื่อให้เรียกเมธอดได้
        IRemoteControl myTV = new SonyTV();
        myTV.TurnOn();
        myTV.ChannelUp();
        myTV.ChannelDown();
        myTV.TurnOff();

        IRemoteControl myLamp = new DesktopLamp();
        myLamp.TurnOn();
        myLamp.ChannelUp();
        myLamp.ChannelDown();
        myLamp.TurnOff();
    }
}
