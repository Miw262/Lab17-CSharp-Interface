using System;

interface IMovable
{
    void Move(); // ✅ ลบ public ออก
}
interface ISpeakable
{
    void Speak(); // ✅ ลบ public ออก
}

abstract class Animal : IMovable, ISpeakable
{
    public abstract void Move(); // ✅ public อยู่ข้างหน้า abstract
    public abstract void Speak(); // ✅ ต้องมีเมธอดนี้เพื่อให้ Animal ใช้ ISpeakable ได้
}

class Dog : Animal
{
    public override void Move()
    {
        Console.WriteLine("Dog moves by running on the ground");
    }

    public override void Speak()
    {
        Console.WriteLine("Dog barks");
    }
}

class Fish : Animal
{
    public override void Move()
    {
        Console.WriteLine("Fish moves by swimming in the water");
    }

    public override void Speak()
    {
        Console.WriteLine("Fish does not make sound");
    }
}

class Bird : Animal
{
    public override void Move()
    {
        Console.WriteLine("Bird moves by flying in the air");
    }

    public override void Speak()
    {
        Console.WriteLine("Bird chirps");
    }
}

class Program
{
    static void Main()
    {
        Animal[] animals = new Animal[3];
        animals[0] = new Dog();
        animals[1] = new Bird();
        animals[2] = new Fish();

        foreach (var animal in animals)
        {
            animal.Move();
            animal.Speak(); // ✅ เรียก Speak() ได้แล้ว
        }
    }
}
