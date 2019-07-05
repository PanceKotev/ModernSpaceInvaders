# ModernSpaceInvaders
A visual programming project



Modern Space Invaders

Проект по Визуелно Програмирање
Изработиле: Панче Котев и Јане Стојилков

Краток опис на апликацијата: 
Modern Space Invaders е игра која е базирана на играта наречена Space Invaders. Играчот контролира свемирски брод кој треба да уништи бранови од противнички свемирски бродови преку пукање на ласери и избегнување на противничките ласери. Во некои од противничките бродови може да се падне појачуавање на брзината на ласерот или бројот на испукани ласери на бродот на играчот или зголемување на животите на бродот . Во играта се минува нивото ако ги играчот ги уништи противничките бродови, а се губи доколку го погодат бродот на играчот 3 пати или доколку играчот не ги уништи сите бродови на време. Играта има бесконечно нивоа така што таа завршува кога играчот ќе изгуби. Доколку играта заврши се прашува играчот дали сака повторно да игра или не. Ирата е составена од 8 класи: 

Класи:
1. Enemy: се чува локација на противничкиот брод, големина, брзина, променлива за дали бродот е уништен и објект од класата Projectile за проектил кој го испукува бродот.

2.Ship: се чува локација на бродот на играчот, големина, брзина.

3.Projectile: се чуват координати од каде што кренува проектилот, брзина на проектилот, големина и bool променлива за дали е испукан од играчот или противнички брод.

4.Gift: се чува локација и тип на појачување.

5.Star: се чува локација на ѕвездите што се во позадина.

6.Upgrade: се чува од кој тип ќе е појачувањето на играчот.

7.Level: се чува колку непријатели ќе има во нивото, и тежината на нивото.	

8.Game:се чуваат објекти од типот Projectile за проектилита на бродот, Ship за бродот на играчот, матрица од  Enemy за противничките бродови, листа од Star за позадина, листа од Gift за појачувањата, Level за ниво и променлива за колку животи има останато бродот.
Детално објаснување на класата Game:
Во класата Game се чуваат сите податоци од аспектот на играта и завршните функции во апликацијата. Сите функции се објаснети со xml summary.
 
Ова се главните податоци кои се користени во класата Game.
Функции на класата Game:
-Прво ја имаме функцијата Shoot() во која се одредува дали е достигната максимумот број на испукани проектили и доколку не е креира нов проектил кој испукува од бродот на играчот.
- shipHit() прво проверува дали бродот е удрен од противнички брод и доколку е играта завршува, потоа проверува дали бродот е удрен од проектил и доколку е се намалуваат животите на бродот и ако стигнат до 0 играта завршува, а доколку е над 0 животите се намалуваат за еден.
- enemyHit() прво проверува за секој непријателски брод од матрицата дали е погоден и не е уништен и доколку и двата услови се исполнети го трга тој брод, Score се зголемува за 100 и има 5% шанси да пушти појачување.
- Draw(Graphics g) ја исцртува играта така што прво ја исцртува позадината, потоа нивото, па играчот,појачувања и на крај проектили доколку има испукани.
- generateGift(Point p) генерира појачување  со почетни координати од p и има 5% шанси да генерира ново појачување со координати на уништениот противничјки брод.
- moveProjectiles() ги движи проектилите испукани од бродот на играчот нагоре се додека не стигнат до врвот на и потоа ги брише.
- nextLevel() проверува дали сите непријатели од бранот се мртви и доколку се го зголемува Score за тежината на нивото помножена по 250 и генерира ново ниво.
- Update() ги вклучува сите функции за движење и детектирање што се во играта.
- GenerateStars() ги креира ѕвездите во позадината на нивото.
- moveGifts() ги придвижува сите појачувања надолу додека не дојдат до дното на формата и доколку стигнат ги брише.
-За крај функцијата takeGift(Ship s) проверува дали има генерирани појачувања и доколку има проверува дали се судираат со бродот и ако тоа е точно го додава типот на појачување на бродот и го брише појачувањето.

Упатство за користење и изглед на играта:
Апликацијата е составена од 3 форми. Кога ќе се уклучи играта се отвара стартната форма и на неа има 3 копчиња, едно за почнување на нова игра, едно за контроли и едно за гасење на играта. Изгледот на формата е ваков:
 


-Со клик на копчето New Game се отвара нова форма во која се креира играта. Бродот се придвижува со стрелките и на space испукува проектили.Изгледот на таа форма е вака:

 

-Со кликање на копчето Controls од стартната форма оди во формата ControlsForm каде што се прикажани контролите за управување на бродот. Таа изгледа вака:
 
