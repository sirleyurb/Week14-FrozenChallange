using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace FrozenChallange
{
    class Program
    {
        class Frozen
        {
            string name;
            string gift;
            string price;


            public Frozen(string _name, string _gift, string _price)
            {
                name = _name;
                gift = _gift;
                price = _price;
            }

            public string Name
            {
                get { return name; }
            }

            public string Gift
            {
                get { return gift; }
            }

            public string Price
            {
                get { return price; }
            }
        }
        class CharacterList
        {
            List<Frozen> characters;

            public CharacterList()
            {
                characters = new List<Frozen>();
            }

            public void AddCharactersToList(string name, string gift, string price)
            {
                Frozen newChar = new Frozen(name, gift, price);
                characters.Add(newChar);
            }

            public void PrintAllCharacters()
            {
                foreach (Frozen frozen in characters)
                {
                    Console.WriteLine($"{frozen.Name} wants {frozen.Price} {frozen.Gift} for christmas");
                }
            }
        }

        static void Main(string[] args)
        {
            string filePath = @"C:\Users\opilane\Samples";
            string fileName = @"Frozen.txt";
            string fullFilePath = Path.Combine(filePath, fileName);


            string[] linesFromFile = File.ReadAllLines(fullFilePath);

            CharacterList myCharacters = new CharacterList();

            foreach (string line in linesFromFile)
            {
                string[] tempArray = line.Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
                string characterName = tempArray[0];
                string characterGift = tempArray[1];
                string characterPrice = tempArray[2];

                myCharacters.AddCharactersToList(characterName, characterGift, characterPrice);
            }

            myCharacters.PrintAllCharacters();
        }
    }
}
