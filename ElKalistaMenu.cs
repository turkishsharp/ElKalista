using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LeagueSharp;
using LeagueSharp.Common;
using System.Drawing;


namespace ElKalista
{

    public class ElKalistaMenu
    {
        public static Menu _menu;

        public static void Initialize()
        {
            _menu = new Menu("ElKalista(TR)", "menu", true);

            //ElKalista.Orbwalker
            var orbwalkerMenu = new Menu("Orbwalker", "orbwalker");
            Kalista.Orbwalker = new Orbwalking.Orbwalker(orbwalkerMenu);
            _menu.AddSubMenu(orbwalkerMenu);

            //ElKalista.TargetSelector
            var targetSelector = new Menu("Hedef Secme", "TargetSelector");
            TargetSelector.AddToMenu(targetSelector);
            _menu.AddSubMenu(targetSelector);

            var cMenu = new Menu("Kombo", "Combo");
            cMenu.AddItem(new MenuItem("ElKalista.Combo.Q", "Q'yu Kullan").SetValue(true));
            cMenu.AddItem(new MenuItem("ElKalista.Combo.E", "E'yi Kullan").SetValue(true));
            cMenu.AddItem(new MenuItem("ElKalista.Combo.R", "R'yi Kullan").SetValue(true));
            cMenu.AddItem(new MenuItem("ElKalista.sssssssss", ""));
            cMenu.AddItem(new MenuItem("ElKalista.ComboE.Auto", "Stacklenmis E'yi Kullan").SetValue(true));
            cMenu.AddItem(new MenuItem("ElKalista.ssssddsdssssss", ""));

            cMenu.AddItem(new MenuItem("ElKalista.hitChance", "Q'nun Vurma Sansi").SetValue(new StringList(new[] { "Dusuk", "Orta", "Yuksek", "Cok Yuksek" }, 3)));
            cMenu.AddItem(new MenuItem("ElKalista.SemiR", "Yari Otomatik R").SetValue(new KeyBind("T".ToCharArray()[0], KeyBindType.Press)));
            cMenu.AddItem(new MenuItem("ComboActive", "Kombo!").SetValue(new KeyBind(32, KeyBindType.Press)));
            _menu.AddSubMenu(cMenu);

            var hMenu = new Menu("Dürtme", "Harass");
            hMenu.AddItem(new MenuItem("ElKalista.Harass.Q", "Dürtmek Icin Q Kullan").SetValue(true));
            hMenu.AddItem(new MenuItem("ElKalista.minmanaharass", "Minumum Mana")).SetValue(new Slider(55));
            hMenu.AddItem(new MenuItem("ElKalista.hitChance", "Q'nun Vurma Sansi").SetValue(new StringList(new[] { "Dusuk", "Orta", "Yuksek", "Cok Yuksek" }, 3)));

            hMenu.SubMenu("AutoHarass").AddItem(new MenuItem("ElKalista.AutoHarass", "[Devamlı] Otomatik Dürtme", false).SetValue(new KeyBind("U".ToCharArray()[0], KeyBindType.Toggle)));
            hMenu.SubMenu("AutoHarass").AddItem(new MenuItem("ElKalista.UseQAutoHarass", "Q'yu Harasta Kullan").SetValue(true));
            hMenu.SubMenu("AutoHarass").AddItem(new MenuItem("ElKalista.harass.mana", "Otomatik Dürtme İçin Mana")).SetValue(new Slider(55));

            _menu.AddSubMenu(hMenu);

            var lMenu = new Menu("Koridor Temizleme", "Clear");
            lMenu.AddItem(new MenuItem("useQFarm", "Q'yu Kullan").SetValue(true));
            lMenu.AddItem(new MenuItem("ElKalista.Count.Minions", "Q İle Öldürülebilecek Minyon Sayısı >=").SetValue(new Slider(2, 1, 5)));
            lMenu.AddItem(new MenuItem("useEFarm", "Use E").SetValue(true));
            lMenu.AddItem(new MenuItem("ElKalista.Count.Minions.E", "E İle Öldürülebilecek Minyon Sayısı >=").SetValue(new Slider(2, 1, 5)));
            lMenu.AddItem(new MenuItem("useEFarmddsddaadsd", ""));
            lMenu.AddItem(new MenuItem("useQFarmJungle", "Q'yu Jungle Moblarında Kullan").SetValue(true));
            lMenu.AddItem(new MenuItem("useEFarmJungle", "E'yi Jungle Moblarında Kullan").SetValue(true));
            lMenu.AddItem(new MenuItem("useEFarmddssd", ""));
            lMenu.AddItem(new MenuItem("minmanaclear", "Koridor Temizleme İçin Minumum Mana ")).SetValue(new Slider(55));

            _menu.AddSubMenu(lMenu);


            var itemMenu = new Menu("Eşyalar", "Items");
            itemMenu.AddItem(new MenuItem("ElKalista.Items.Youmuu", "Youmuu'nun Hayaletkılıcı'nı Kullan").SetValue(true));
            itemMenu.AddItem(new MenuItem("ElKalista.Items.Cutlass", "Bilgewater Palası'nı Kullan").SetValue(true));
            itemMenu.AddItem(new MenuItem("ElKalista.Items.Blade", "Mahvolmuş Kralın Kılıcı'nı Kullan").SetValue(true));
            itemMenu.AddItem(new MenuItem("ElKalista.Harasssfsddass.E", ""));
            itemMenu.AddItem(new MenuItem("ElKalista.Items.Blade.EnemyEHP", "Düşmanın Yüzdelik Canı").SetValue(new Slider(80, 100, 0)));
            itemMenu.AddItem(new MenuItem("ElKalista.Items.Blade.EnemyMHP", "Benim Yüzdelik Canım").SetValue(new Slider(80, 100, 0)));
            _menu.AddSubMenu(itemMenu);


            var setMenu = new Menu("Gizli Özellikler", "SSS");
            setMenu.AddItem(new MenuItem("ElKalista.misc.save", "Partnerini R ile Kurtar").SetValue(true));
            setMenu.AddItem(new MenuItem("ElKalista.misc.allyhp", "Partnerin Yüzdelik Canı").SetValue(new Slider(25, 100, 0)));
            setMenu.AddItem(new MenuItem("useEFarmddsddsasfsasdsdsaadsd", ""));
            setMenu.AddItem(new MenuItem("ElKalista.E.Auto", "E'yi Otomatik Kullan").SetValue(true));
            setMenu.AddItem(new MenuItem("ElKalista.E.Stacks", "E'yi Otomatik Kullanmak İçin Stack Sayısı >=").SetValue(new Slider(10, 1, 20)));
            setMenu.AddItem(new MenuItem("useEFafsdsgdrmddsddsasfsasdsdsaadsd", ""));
            setMenu.AddItem(new MenuItem("ElKalista.misc.ks", "Kill Çalma Modu").SetValue(false));
            setMenu.AddItem(new MenuItem("ElKalista.misc.junglesteal", "Jungle Mobu Çalma Modu").SetValue(true));

            _menu.AddSubMenu(setMenu);

            //ElKalista.Misc
            var miscMenu = new Menu("Çizimler", "Misc");
            miscMenu.AddItem(new MenuItem("ElKalista.Draw.off", "Çizimleri Kapat").SetValue(false));
            miscMenu.AddItem(new MenuItem("ElKalista.Draw.Q", "Q'yu Çiz").SetValue(new Circle()));
            miscMenu.AddItem(new MenuItem("ElKalista.Draw.W", "W'yu Çiz").SetValue(new Circle()));
            miscMenu.AddItem(new MenuItem("ElKalista.Draw.E", "E'yi Çiz").SetValue(new Circle()));
            miscMenu.AddItem(new MenuItem("ElKalista.Draw.R", "R'yi Çiz").SetValue(new Circle()));
            miscMenu.AddItem(new MenuItem("ElKalista.Draw.Text", "Metinleri Göster").SetValue(true));

            var dmgAfterE = new MenuItem("ElKalista.DrawComboDamage", "E Damage'ini Goster").SetValue(true);
            var drawFill = new MenuItem("ElKalista.DrawColour", "Rengi Seç", true).SetValue(new Circle(true, Color.FromArgb(204, 204, 0, 0)));
            miscMenu.AddItem(drawFill);
            miscMenu.AddItem(dmgAfterE);



            EDamage.DamageToUnit = Kalista.GetComboDamage;
            EDamage.Enabled = dmgAfterE.GetValue<bool>();
            EDamage.Fill = drawFill.GetValue<Circle>().Active;
            EDamage.FillColor = drawFill.GetValue<Circle>().Color;

            dmgAfterE.ValueChanged += delegate (object sender, OnValueChangeEventArgs eventArgs)
            {
                EDamage.Enabled = eventArgs.GetNewValue<bool>();
            };

            drawFill.ValueChanged += delegate (object sender, OnValueChangeEventArgs eventArgs)
            {
                EDamage.Fill = eventArgs.GetNewValue<Circle>().Active;
                EDamage.FillColor = eventArgs.GetNewValue<Circle>().Color;
            };

            _menu.AddSubMenu(miscMenu);

            //Here comes the moneyyy, money, money, moneyyyy
            var credits = new Menu("Yapımcı", "jQuery");
            credits.AddItem(new MenuItem("ElKalista.Paypal", "Yapımcıya Paypal İle Destek Olmak İçin:"));
            credits.AddItem(new MenuItem("ElKalista.Email", "info@zavox.nl"));
            _menu.AddSubMenu(credits);

            _menu.AddItem(new MenuItem("422442fsaafs4242f", ""));
            _menu.AddItem(new MenuItem("422442fsaafsf", "Alpha Versiyon: 1.0.1.4"));
            _menu.AddItem(new MenuItem("fsasfafsfsafsa", "jQuery tarafında yapılıp"));
            _menu.AddItem(new MenuItem("fsasfafsfsafsaas", "ShamelessPerson Tarafından Çevrilmiştir"));

            _menu.AddToMainMenu();

            Console.WriteLine("Menu Loaded");
        }
    }
}
