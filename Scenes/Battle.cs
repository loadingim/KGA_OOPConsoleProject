using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using endTrpg.Monsters;
using endTrpg.Game;
using System.Drawing;
using System.Xml.Linq;
using endTrpg.Player;
using endTrpg.Item;

namespace endTrpg.Scenes
{
    public class Battle : Scene
    {
        Random rand = new Random();
        Monster mob = new Monster();
        MonsterBuilder mongsil = new MonsterBuilder();
        MonsterBuilder slime = new MonsterBuilder();
        MonsterBuilder arcticfox = new MonsterBuilder();
        MonsterBuilder sam = new MonsterBuilder();
        MonsterBuilder isaac = new MonsterBuilder();
        int choice;

        public Battle(GameData game) : base(game)
        {

        }

        public override void Enter()
        {
            

            // TODO : 랜덤 몬스터 출연

            
            mongsil.SetName("양");
            mongsil.SetExp(2);
            mongsil.SetApp("하얀 털을 가진 양");
            mongsil.SetHp(30);
            mongsil.SetAttack(5);
            mongsil.SetLoot("하얀색 양털");
            mongsil.SetAttackRange("0칸");
            mongsil.SetAttackStyle("웅크리기");

            
            slime.SetName("슬라임");
            slime.SetExp(5);
            slime.SetApp("반투명한 액체의 청소부");
            slime.SetHp(40);
            slime.SetAttack(15);
            slime.SetLoot("슬라임의 체액");
            slime.SetAttackRange("1칸");
            slime.SetAttackStyle("몸통박치기");


            arcticfox.SetName("북극 여우");
            arcticfox.SetExp(10);
            arcticfox.SetApp("연 푸른 냉기를 내뿜는 여우");
            arcticfox.SetHp(60);
            arcticfox.SetAttack(20);
            arcticfox.SetLoot("하얀모피");
            arcticfox.SetAttackRange("2X2칸");
            arcticfox.SetAttackStyle("냉기안개");

            sam.SetName("지나가던 산적의 삼촌");
            sam.SetExp(5);
            sam.SetApp("따뜻한 인상의 삼촌이다.");
            sam.SetHp(100);
            sam.SetAttack(20);
            sam.SetLoot("조카 줄 고기");
            sam.SetAttackRange("1x1칸");
            sam.SetAttackStyle("인자한 웃음");

            isaac.SetName("아이작");
            isaac.SetExp(15);
            isaac.SetApp("길을 잃은 괴물의 아이");
            isaac.SetHp(3);
            isaac.SetAttack((int)3.5);
            isaac.SetLoot("아이작의 눈물");
            isaac.SetAttackRange("23.75칸");
            isaac.SetAttackStyle("알 수 없음");


            switch (rand.Next(1, 6))
            {
                case 1:
                    mob = mongsil.Build();
                    break;
                case 2:
                    mob = slime.Build();
                    break;
                case 3:
                    mob = arcticfox.Build();
                    break;
                case 4:
                    mob = sam.Build();
                    break;
                case 5:
                    mob = isaac.Build();
                    break;
                default:
                    break;
            }

            Console.Clear();
            
            Thread.Sleep(2000);
            sceneState = "전투선택";

        }

        public override void Exit()
        {
            
        }

        public override void Input()
        {
            // TODO : 전투 입력
            int.TryParse(Console.ReadLine(), out choice);
        }

        public override void Render()
        {
            // TODO : 전투 상황 출력
            if (sceneState == "전투선택")
            {
                Console.WriteLine($"{mob.name}과(와) 조우했습니다.");
                Console.WriteLine($"몬스터 설명 : {mob.app}");
                Console.WriteLine("전투하시겠습니까?");
                Console.WriteLine("=============================================");
                Console.WriteLine("1. 전투한다");
                Console.WriteLine("2. 도망간다");
            }
            else if (sceneState == "전투실행")
            {
                Console.WriteLine($"몬스터 : {mob.name,-6}");
                Console.WriteLine($"체력 : {mob.hp,+3} / {mob.maxHp}");
                Console.WriteLine("=============================================");
                Console.WriteLine("1. 기본공격");
                Console.WriteLine("2. 스킬");
                Console.WriteLine("3. 도망");

                game.player.ShowInfo();

                



                
            }
        }

        public override void Update()
        {
            // TODO : 전투 진행
            if (sceneState == "전투선택")
            {
                if (choice == 1)
                {
                    sceneState = "전투실행";
                    Console.Clear();
                }
                else
                {
                    switch (rand.Next(1, 6))
                    {
                        case 1:
                            mob = mongsil.Build();
                            break;
                        case 2:
                            mob = slime.Build();
                            break;
                        case 3:
                            mob = arcticfox.Build();
                            break;
                        case 4:
                            mob = sam.Build();
                            break;
                        case 5:
                            mob = isaac.Build();
                            break;
                        default:
                            break;
                    }

                    game.ReturnScenes();
                    game.playerPos = game.backPlayerPos;
                }
            }
            else if (sceneState == "전투실행")
            {
                if (choice == 1)
                {
                    Console.WriteLine($"{game.player.name}은(는) 기본 공격을 하였다.");
                    Console.WriteLine($"{mob.name}은(는) {game.player.attack}의 데미지를 입었다.");
                    mob.hp = mob.hp - game.player.attack;
                    
                    Console.WriteLine($"{mob.name}은(는) 반격을 하였다.");
                    Console.WriteLine($"{game.player.name}은(는) {mob.attack}만큼의 데미지를 입었다.");
                    game.player.curHP = game.player.curHP - mob.attack;
                    Wait(1);
                    Console.Clear();
                }

                else if (choice == 2)
                {

                    Console.WriteLine($"{game.player.name}은(는) 스킬 공격을 하였다.");
                    game.player.Skill(mob);
                    Console.WriteLine($"{mob.name}은(는) {mob.maxHp - mob.hp}의 데미지를 입었다.");

                    Console.WriteLine($"{mob.name}은(는) 반격을 하였다.");
                    Console.WriteLine($"{game.player.name}은(는) {mob.attack}만큼의 데미지를 입었다.");
                    game.player.curHP = game.player.curHP - mob.attack;
                    Wait(1);
                    Console.Clear();
                    
                }
            }
            if (mob.hp <= 0)
            {
                Console.WriteLine($"{mob.name}을(를) 쓰러트렸습니다!!");
                game.inven.Add(mob);
                Wait(1);
                game.ReturnScenes();
                game.playerPos = game.backPlayerPos;

                game.player.killCount++;
            }
            if (game.player.curHP <= 0)
            {
                Console.WriteLine($"{game.player.name}이(가) 쓰러졌습니다.");
                Console.WriteLine("눈 앞이 어두워졌습니다.");

                Wait(2);

                Environment.Exit(0);
            }
        }
    }
}
