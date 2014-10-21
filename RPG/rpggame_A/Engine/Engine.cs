using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Capec.RPGGame.Constructions;
using Capec.RPGGame.Utility;
using Capec.RPGGame.UI;
using Capec.RPGGame.Characters;
using Capec.RPGGame.Interfaces;
using Capec.RPGGame.Items;

namespace Capec.RPGGame.Engine
{
    class Engine
    {
        private Timer timer;
        public static Engine engine;
        private Label infoPanel;
        private GameWindow space;
        private int time;
        private IControlerable controler;    
        private IDraw DrawerDevice;
        private WarUnit hero;
        private WarUnit boss;
        private WarUnit stone;
        private List<Magic> magics;
        private List<WarUnit> warUnits;
        private Brain bossBrain;
        private IControlerable bossControler;
        private Inventory inventory;
        private Interfaces.Items fireItem;
        private Interfaces.Items stoneItem;
        private Interfaces.Items lifeItem;
        private Interfaces.Items charmItem;
        private List<Interfaces.Items> items;

        public static Engine Istanse
        {
            get 
            { 
                return engine;
            }
        }

        static Engine()
        {
            engine = new Engine();

        }

        private Engine(){

           
        }

        public void Run ()
        {
            time = 0;
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            
            InitialScene();
          
            controler = new KeyBoard(space);
            DrawerDevice = new DrawGameObject(space);
            bossBrain = new Brain();
            bossControler = new BrainControler(bossBrain);
            InitialHero();
            QueryControler(controler, hero);
            QueryControler(bossControler, boss);   
            Application.Run(space);
             
        }

        private void InitialScene()
        {
            magics = new List<Magic>();
            warUnits = new List<WarUnit>();
            items = new List<Interfaces.Items>();
            space = new GameWindow();
            timer = new Timer();
            timer.Interval = 100;
            timer.Tick += new EventHandler(Update);
            timer.Enabled = true;
            timer.Start();
            infoPanel = new Label();
            infoPanel.Width = space.Width;
            infoPanel.ForeColor = Color.DarkOrange;
            infoPanel.BackColor = Color.DarkRed;
            infoPanel.Font = new Font("Algerian", 11);
            infoPanel.Text = "INFO PANEL: ";
            inventory = new Inventory(space.Width / 2 - 150, space.Height - 75, space);
            
            space.Controls.Add(infoPanel);
        }






        private void QueryControler(IControlerable controler, WarUnit unit)
        {
            controler.MoveUp += (sender, args) =>
            {
                MoveHeroUp(unit);
            };
            controler.MoveDown += (sender, args) =>
            {
                MoveHeroDown(unit);
            };
            controler.MoveToLeft += (sender, args) =>
            {
                MoveHeroToLeft(unit);
            };
            controler.MoveToRight += (sender, args) =>
            {
                MoveHeroToRight(unit);
            };
            controler.ThrowMagic += (sender, args) =>
            {
                var magicArgs = args as CastEventArgs;
                HeroThrowMgic(magicArgs.mx, magicArgs.my);
            };

        }

        private void MoveHeroToRight(WarUnit unit)
        {

           unit.Direction = new Vector2(-1, 0);
           
            TestPoint(unit); 
        }

        private void MoveHeroToLeft(WarUnit unit)
        {
            unit.Direction = new Vector2(1, 0);
           
            TestPoint(unit); 
        }

        private void MoveHeroDown(WarUnit unit)
        {
            unit.Direction = new Vector2(0, 1);
           
            TestPoint(unit); 
        }

        private void MoveHeroUp(WarUnit unit)
        {
            unit.Direction = new Vector2(0, -1);
            
            TestPoint(unit); 
        }

//---------------------------------------------------------------------
        private void Update(object sender, EventArgs e)
        {
            time++;
            UpdateInfoPanel();
            RemoveTimedoutMagics();
            MoveMovableMagic();
            BossTakeDecision();          
            this.DrawerDevice.RedrawObject(this.hero);
            this.DrawerDevice.RedrawObject(this.boss);
  
        }

//---------------------------------------------------------

        private void BossTakeDecision() 
        {
            if (time % 10 == 0)
            {
                bossBrain.TakeDecision();
            }
            else
            {
                //boss.Move();
                TestPoint(boss);
            }
        }

        private void TestPoint(WarUnit movableObject)
        {

          double  tempX = movableObject.X;
          double  tempY = movableObject.Y;

          double tempHeroX = hero.X;
          double tempHeroY = hero.Y;
          double tempBossX = boss.X;
          double tempBossY = boss.Y;



                movableObject.Move();

                if (movableObject.X < 0 
                    || movableObject.X+movableObject.Width>space.Width)
                {
                    movableObject.X = tempX; //movableObject.Direction = new Vector2(0, 0);
                }
                else if (movableObject.Y < infoPanel.Height 
                    || movableObject.Y +movableObject.Height> space.Height) 
                {
                    movableObject.Y = tempY; //amovableObject.Direction = new Vector2(0, 0);
                }
                if (IsInRange(movableObject, stone)) 
                {
                    movableObject.X = tempX;
                    movableObject.Y = tempY;
                }
                if (IsInRange(hero, boss)) 
                {

                    boss.X = tempBossX;
                    boss.Y = tempBossY;
                    hero.X = tempHeroX;
                    hero.Y = tempHeroY;
                    hero.Life = hero.Life - 30;
                    
                }

               
                foreach (Interfaces.Items item in items) 
                {
                    if (IsInRange(hero, item))
                    {
                        //tuk trqbwa da se izpolzwa remove
                        item.X = 0;
                        item.Y = -10;
                        DrawerDevice.RedrawObject(item);
                        inventory.AddItem(item);
                        hero.Life += inventory.GiveLifeSkill;
                        inventory.GiveLifeSkill = 0;
                        hero.Defence += inventory.GiveDefenceSkill;
                        inventory.GiveDefenceSkill = 0;
                        hero.TakeLIfe += inventory.GiveAttackSkill;
                        inventory.GiveAttackSkill = 0;
                    }
                 
                }

        }



        private void UpdateInfoPanel() 
        {
            infoPanel.Text = String.Format("HERO INFO: Name:  {0}, LIFE:  {1}, DEFFENCE:  {2}, ATTAK:  {3}", hero.Name,hero.Life, hero.Defence, hero.TakeLIfe);
            
        }

      
        private void InitialHero()
        {
            hero = new Characters.Characters(100, 100, 110, 100, 100, 2, 5, 30, 10, 20,
                new Vector2(0, 0), SpriteType.Mage, Shared.HeroHumanName, Shared.HeroHumanMaxLife);

            boss = new Characters.Characters(100, 300, 110, 110, 200, 2, 5, 30, 10, 10,
                new Vector2(0, 0), SpriteType.Ghoul, Shared.BossMonsterName, Shared.BossMonsterMaxLife);

            stone = new Characters.Characters(350, 250, 310, 110, 200, 2, 5, 30, 10, 10,
                new Vector2(0, 0), SpriteType.Wall, Shared.BossMonsterName, Shared.BossMonsterMaxLife);

            fireItem = new FireBallMagic(500, 40, 30, 30, SpriteType.FireMagic, 1, 1, 5 );

            stoneItem = new StoneMagic(890, 515, 30, 30, SpriteType.StoneMagic, 1, 2, 10);

            lifeItem = new StoneMagic(50, 130, 30, 30, SpriteType.LifeMagic, 50, 2, 1);

            charmItem = new StoneMagic(110, 400, 30, 30, SpriteType.CharmMagic, 5, 5, 5);


            DrawerDevice.AddObject(stoneItem);
            DrawerDevice.AddObject(fireItem);
            DrawerDevice.AddObject(lifeItem);
            DrawerDevice.AddObject(charmItem);
            DrawerDevice.AddObject(hero);
            DrawerDevice.AddObject(boss);
            DrawerDevice.AddObject(stone);       
            warUnits.Add(stone);
            warUnits.Add(boss);
            warUnits.Add(hero);
            items.Add(fireItem);
            items.Add(lifeItem);
            items.Add(charmItem);
            items.Add(stoneItem);


        }
//---------------------------------ne se izpolzwa
        public void PlayNextMove()
        {
            RemoveTimedoutMagics();
               this.DrawerDevice.RedrawObject(this.hero);
        }
//---------------------------------------------------
        private void RemoveTimedoutMagics()
        {
            foreach (var mag in this.magics)
            {
                mag.CurrentTimeout += Shared.TimedoutFireBallMax;
                if (mag.HasTimeout)
                {               
                    this.DrawerDevice.RemoveObject(mag);
                }
            }
            this.magics.RemoveAll(s => s.HasTimeout);
        }

        private bool IsInRange(IGameObject object1, IGameObject object2) 
        {
            double object1x1 = object1.X;
            double object1y1 = object1.Y; 
            double object1x2 = object1.X + object1.Width;
            double object1y2 = object1.Y + object1.Height;

            double object2x1 = object2.X;
            double object2y1 = object2.Y;
            double object2x2 = object2.X + object2.Width;
            double object2y2 = object2.Y + object2.Height;


            return (object1x1 < object2x2 && object1x2 > object2x1 &&
                object1y1 < object2y2 && object1y2 > object2y1);

        }

        private void HeroThrowMgic(int mx,int my) 
        {
            if (inventory.focus == "fireBox")
            {
                double magicXFromHero = mx - hero.X;
                double magicYFromHero = my - hero.Y;

                if (magicXFromHero * magicXFromHero + magicYFromHero * magicYFromHero < 40000)
                {
                    var magic = hero.ThrowMagic(mx, my, MagicType.FireBall);
                    ProcessMagic(magic);
                }

            } 
            if (inventory.focus == "stoneBox")
            {

                double magicXFromHero = mx - hero.X;
                double magicYFromHero = my - hero.Y;
                var magic = hero.ThrowMagic(mx, my, MagicType.Stone);
              //  ProcessMagic(magic);
                this.magics.Add(magic);
                this.DrawerDevice.AddObject(magic);
            }



        }

        private void ProcessMagic(Magic magic)
        {
           

           var participants= this.warUnits.Where(s =>  this.IsInRange(magic, s));
           foreach (var participant in participants)
           {

               var reaction = participant.reactToWeapon(magic.MagicType);

               switch (reaction) 
               {
                   case Reaction.ReceiveDemage:

                       int result = participant.Life- magic.TakeLife;//+magic.caster
                       //if ....
                       participant.Life = result;
                       break;
                   case Reaction.ReceiveLife:
                       
                       break;
               }
           }
            this.magics.Add(magic);
            this.DrawerDevice.AddObject(magic);
        }

        public void MoveMovableMagic()
        {
            foreach (var item in magics)
            {
                switch (item.SpriteType)
                {
                    case SpriteType.Stone:
                        (item as Stoune).Move();
                        DrawerDevice.RedrawObject(item);
                        break;
                }
            }
        }
    }
}
