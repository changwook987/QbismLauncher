using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;

namespace QbismLauncher
{
    static class Fonts
    {
        private static readonly PrivateFontCollection pfc = new();

        public static readonly Dictionary<string, FontFamily> FontFamilies;

        public static readonly FontFamily NanumGothic;
        public static readonly FontFamily NanumGothicExtraBold;
        public static readonly FontFamily NanumGothicLight;

        static Fonts()
        {
            FontFamilies = [];
            var cd = AppDomain.CurrentDomain.BaseDirectory;
            try
            {
                pfc.AddFontFile(cd + @"\Resources\Fonts\NanumGothic\NanumGothic.ttf");
                pfc.AddFontFile(cd + @"\Resources\Fonts\NanumGothic\NanumGothicBold.ttf");
                pfc.AddFontFile(cd + @"\Resources\Fonts\NanumGothic\NanumGothicExtraBold.ttf");
                pfc.AddFontFile(cd + @"\Resources\Fonts\NanumGothic\NanumGothicLight.ttf");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }

            var families = pfc.Families;

            foreach (var family in families)
            {
                FontFamilies.Add(family.Name, family);
            }

            NanumGothic = FontFamilies["나눔고딕"];
            NanumGothicExtraBold = FontFamilies["나눔고딕 ExtraBold"];
            NanumGothicLight = FontFamilies["나눔고딕 Light"];
        }
    }
}