using NUnit.Framework;
using OTS2026_GrupaC.Exceptions;
using OTS2026_GrupaC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OTS2026_GrupaC.Test
{
    [TestFixture]
    internal class GameTest
    {
        private Game game;

        [SetUp]
        public void SetUp()
        {
            game = new Game(new Location(1, 2, 0), new Location(1, 15, 0));
        }



        //F1 Inicijalizacija igre

        //Validne klase ekvivalencije: 
        //Kretanje po mapi: od (0,0,0) do (30,30,30)  bez (od (10,5,0) do (30, 10, 10) i bez (od (0, 20, 0) do (20, 25, 20)
        //Granicne vrednosti za x koordinate: -1,0,1,9,10,11,19,20,21,29,30,31   
        //Granicne vrednosti za y koordinate: -1,0,1,4,5,6,9,10,11,19,20,21,24,25,26,29,30,31
        //Granicne vrdnosti za y koordinate: -1,0,1,9,10,11,19,20,21,29,30,31
        //Nevalidne klase ekvivalencije: (-1,-1,-1), (50,50,50), (9,9,50) - ako je van mape, bar jedna od koordinata ne pripada mapi (manje od  ili vece od 30)
        //                               (11,6,0), (2,22,3) - ako je neka od koordinata u nedoyvoljenim oblastima 
        //predstavnik validne klase ekvivalencije npr: (3,6,0)

        [TestCase(-1, 22, 60)]
        [TestCase(10, -4, 60)]
        [TestCase(-1, 22, 10)]
        //Pozicije unutar mape
        public void ValidateLocationInsideMap_MustBeInsideMap(int x, int y, int z)
        {
            Location player= new Location(x, y, z);
            Exception ex = Assert.Throws<LocationOutsideOfMapException>((TestDelegate)(() => new Game(player, new Location())));
            Assert.That(ex.Message, Is.EqualTo("Locations must be valid!"));
        }

        [TestCase(12,6,1)]
        [TestCase(1,21,2)]
        //Pozicije u nedozvoljenim oblastima
        public void ValidateLocationInsideMap_BlankSpaces(int x, int y, int z)
        {
            Location player = new Location(x, y, z);
            Location space = new Location(x, y, z);
            Exception ex = Assert.Throws<LocationOutsideOfMapException>((TestDelegate)(() => new Game(player, space)));
            Assert.That(ex.Message, Is.EqualTo("Locations must be valid!"));
        }








       

        //F2 Move Player
        //Validne klase ekvivalencije: 
        //Kretanje po mapi: od (0,0,0) do (30,30,30)  bez (od (10,5,0) do (30, 10, 10) i bez (od (0, 20, 0) do (20, 25, 20)
        //Granicne vrednosti za x koordinate: -1,0,1,9,10,11,19,20,21,29,30,31   
        //Granicne vrednosti za y koordinate: -1,0,1,4,5,6,9,10,11,19,20,21,24,25,26,29,30,31
        //Granicne vrdnosti za y koordinate: -1,0,1,9,10,11,19,20,21,29,30,31
        //Nevalidne klase ekvivalencije: (-1,-1,-1), (50,50,50), (9,9,50) - ako je van mape, bar jedna od koordinata ne pripada mapi (manje od  ili vece od 30)
        //                               (11,6,0), (2,22,3) - ako je neka od koordinata u nedoyvoljenim oblastima 
        //predstavnik validne klase ekvivalencije npr: (3,6,0)
        [TestCase(2,5,0, Move.Up)]
        public void MovePlayerUp(int x, int y, int z, Move move)
        {
             Location player = new Location(x,y,z);
             Game game = new Game(new Location(x,y,z), new Location());
             Location exp= new Location (x,y-1,z);
             game.MovePlayer(Move.Up);
             Assert.That(exp, Is.EqualTo(game.Player.Location));
        }

        [TestCase(2, 5, 0, Move.Right)]
        public void MovePlayerRight(int x, int y, int z, Move move)
        {
            Location player = new Location(x, y, z);
            Game game = new Game(new Location(x, y, z), new Location());
            Location exp = new Location(x+1, y, z);
            game.MovePlayer(Move.Right);
            Assert.That(exp, Is.EqualTo(game.Player.Location));
        }



        [TestCase(2, 5, 0, Move.Left)]
        public void MovePlayerLeft(int x, int y, int z, Move move)
        {
            Location player = new Location(x, y, z);
            Game game = new Game(new Location(x, y, z), new Location());
            Location exp = new Location(x -1, y, z);
            game.MovePlayer(Move.Left);
            Assert.That(exp, Is.EqualTo(game.Player.Location));
        }


        //F3
        //Validne klase ekvivalencije: 
        //Kretanje po mapi: od (0,0,0) do (30,30,30)  bez (od (10,5,0) do (30, 10, 10) i bez (od (0, 20, 0) do (20, 25, 20)
        //Granicne vrednosti za x koordinate: -1,0,1,9,10,11,19,20,21,29,30,31   
        //Granicne vrednosti za y koordinate: -1,0,1,4,5,6,9,10,11,19,20,21,24,25,26,29,30,31
        //Granicne vrdnosti za y koordinate: -1,0,1,9,10,11,19,20,21,29,30,31
        //Nevalidne klase ekvivalencije: (-1,-1,-1), (50,50,50), (9,9,50) - ako je van mape, bar jedna od koordinata ne pripada mapi (manje od  ili vece od 30)
        //                               (11,6,0), (2,22,3) - ako je neka od koordinata u nedoyvoljenim oblastima 
        //predstavnik validne klase ekvivalencije npr: (3,6,0)



        //F4
        //Validne klase ekvivalencije: 
        //Kretanje po mapi: od (0,0,0) do (30,30,30)  bez (od (10,5,0) do (30, 10, 10) i bez (od (0, 20, 0) do (20, 25, 20)
        //Granicne vrednosti za x koordinate: -1,0,1,9,10,11,19,20,21,29,30,31   
        //Granicne vrednosti za y koordinate: -1,0,1,4,5,6,9,10,11,19,20,21,24,25,26,29,30,31
        //Granicne vrdnosti za y koordinate: -1,0,1,9,10,11,19,20,21,29,30,31
        //Nevalidne klase ekvivalencije: (-1,-1,-1), (50,50,50), (9,9,50) - ako je van mape, bar jedna od koordinata ne pripada mapi (manje od  ili vece od 30)
        //                               (11,6,0), (2,22,3) - ako je neka od koordinata u nedoyvoljenim oblastima 
        //predstavnik validne klase ekvivalencije npr: (3,6,0)






        //sakupljanje pcela
        [TestCase(1, 15, 0, false, true)]
        public void UpdatePlayerBee(int x, int y, int z, bool beeCollected, bool expBeeCollected)
        {
            Game game = new Game(new Location(x, y, z), new Location(x, y, z));
            game.Player.BeeCollected = beeCollected;
            game.Map.Tiles[x, y, z].Content = TileContent.Bee;
            game.UpdatePlayer();
            Assert.That(expBeeCollected, Is.EqualTo(game.Player.BeeCollected));
        }
        
        
        //sakupljanje nektara
        [TestCase(6, 2, 0, true, 0, 1)]
        [TestCase(6, 2, 0, false, 2, 3)]
        public void UpdatePlayerNectar(int x, int y, int z, bool BeeCollected, bool amountOfNectar, bool expNectarCollected) 
        {
            Game game = new Game(new Location(x, y, z), new Location(x, y, z));
            game.Map.Tiles[x, y, z].Content = TileContent.Nectar;

            game.UpdatePlayer();
            Assert.That(expAmountOfNectar, Is.EqualTo(game.Player.AmountOfNectar));
        }













       















    }
}
