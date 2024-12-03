using System;

class Program
{
    static void Main(string[] args)
    {
        Game game = new Game();
        game.Start();
    }
}

class Game
{
    private string playerName;
    private bool hasFirstArtifact = false;
    private bool hasSecondArtifact = false;
    private bool hasThirdArtifact = false;
    private bool statueActivated = false;
    private bool keyObtained = false;
    private bool keyUsed = false;

    public void Start()
    {
        Console.WriteLine("Вы просыпаетесь в комнате и пытаетесь вспомнить свое имя.");
        Console.Write("Введите имя вашего персонажа: ");
        playerName = Console.ReadLine();

        while (!keyUsed)
        {
            ShowRoomOptions();
            string choice = Console.ReadLine();
            HandleChoice(choice);
        }

        Console.WriteLine($"Поздравляем, {playerName}! Вы успешно сбежали!");
    }

    private void ShowRoomOptions()
    {
        Console.WriteLine("\nВыберите действие:");
        Console.WriteLine("1. Открыть дверь");
        Console.WriteLine("2. Заглянуть под кровать");
        Console.WriteLine("3. Открыть ящик в углу комнаты");
        Console.WriteLine("4. Открыть вентиляцию");
        Console.WriteLine("5. Взглянуть на тумбочку");
        Console.WriteLine("6. Взглянуть на статую рядом с дверью");
    }

    private void HandleChoice(string choice)
    {
        switch (choice)
        {
            case "1":
                OpenDoor();
                break;
            case "2":
                LookUnderBed();
                break;
            case "3":
                OpenBox();
                break;
            case "4":
                OpenVentilation();
                break;
            case "5":
                LookAtNightstand();
                break;
            case "6":
                LookAtStatue();
                break;
            default:
                Console.WriteLine("Неверный выбор. Пожалуйста, выберите снова.");
                break;
        }
    }

    private void OpenDoor()
    {
        if (keyUsed)
        {
            Console.WriteLine("Вы открываете дверь и успешно сбегаете!");
            return;
        }

        if (!statueActivated)
        {
            Console.WriteLine("Дверь заперта. Вам нужно активировать статую.");
        }
        else if (!keyObtained)
        {
            Console.WriteLine("У вас нет ключа от ящика.");
        }
        else
        {
            Console.WriteLine("Вы открываете дверь с помощью отмычки и сбегаете!");
            keyUsed = true;
        }
    }

    private void LookUnderBed()
    {
        if (!hasFirstArtifact)
        {
            Console.WriteLine("Вы заглянули под кровать и нашли первый артефакт!");
            hasFirstArtifact = true;
        }
        else
        {
            Console.WriteLine("Под кроватью больше ничего нет.");
        }
    }

    private void OpenBox()
    {
        if (keyObtained)
        {
            Console.WriteLine("Вы открываете ящик и находите отмычку от двери!");
            keyUsed = true; // Позволяем открыть дверь
        }
        else
        {
            Console.WriteLine("Ящик заперт. Вам нужно получить ключ.");
        }
    }

    private void OpenVentilation()
    {
        if (!hasSecondArtifact)
        {
            Console.WriteLine("Вы пробуете открыть вентиляцию...");
            Random rand = new Random();
            int attempts = 0;

            while (attempts < 3 && !hasSecondArtifact)
            {
                attempts++;
                if (rand.Next(0, 2) == 1) // 50% шанс на успех
                {
                    Console.WriteLine("Вентиляция открыта! Вы нашли второй артефакт!");
                    hasSecondArtifact = true;
                    return;
                }
                else
                {
                    Console.WriteLine("Вентиляция не открывается...");
                }
            }
            Console.WriteLine("Вы не смогли открыть вентиляцию после трех попыток.");
        }
        else
        {
            Console.WriteLine("Вентиляция уже открыта.");
        }
    }

    private void LookAtNightstand()
    {
        if (!hasThirdArtifact)
        {
            Console.WriteLine("На тумбочке вы находите третий артефакт!");
            hasThirdArtifact = true;
        }
        else
        {
            Console.WriteLine("На тумбочке больше ничего нет.");
        }
    }

    private void LookAtStatue()
    {
        if (!statueActivated && hasFirstArtifact && hasSecondArtifact && hasThirdArtifact)
        {
            Console.WriteLine("Вы активируете статую тремя артефактами!");
            statueActivated = true;
            keyObtained = true; // Получаем ключ от ящика
            Console.WriteLine("Статуя активирована! Вы получили ключ от ящика.");
        }
        else if (statueActivated)
        {
            Console.WriteLine("Статуя уже активирована.");
        }
        else
        {
            Console.WriteLine("Вам не хватает артефактов для активации статуи.");
        }
    }
}
