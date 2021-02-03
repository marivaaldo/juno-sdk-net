using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Juno.Sdk.Models.DirectCheckouts
{
    public class CardLabel
    {
        public const string DEFAULT_CC_MASK = "0000  0000  0000  0000";
        public const string DEFAULT_CVC_MASK = "000";

        public string Name { get; set; }

        public Regex Detector { get; set; }

        public int CardLength { get; set; }

        public int CvcLength { get; set; }

        public string MaskCC { get; set; }

        public string MaskCVC { get; set; }

        public int Order { get; set; }

        private CardLabel() { }

        public static List<CardLabel> GetOrderedLabels()
        {
            var listCardLabels = new List<CardLabel>()
            {
                VISA,
                MASTERCARD,
                AMEX,
                DISCOVER,
                HIPERCARD,
                DINERS,
                JCB_15,
                JCB_16,
                ELO,
                AURA
            };

            return listCardLabels.OrderBy(o => o.Order).ToList();
        }

        #region CardLabel Instances

        public static readonly CardLabel VISA = new CardLabel
        {
            Name = "visa",
            Detector = new Regex("^4"),
            CardLength = 16,
            CvcLength = 3,
            MaskCC = DEFAULT_CC_MASK,
            MaskCVC = DEFAULT_CVC_MASK,
            Order = 99
        };

        public static readonly CardLabel MASTERCARD = new CardLabel
        {
            Name = "mastercard",
            Detector = new Regex("^(5[1-5]|2(2(2[1-9]|[3-9])|[3-6]|7([0-1]|20)))"),
            CardLength = 16,
            CvcLength = 3,
            MaskCC = DEFAULT_CC_MASK,
            MaskCVC = DEFAULT_CVC_MASK,
            Order = 99
        };

        public static readonly CardLabel AMEX = new CardLabel
        {
            Name = "amex",
            Detector = new Regex("^3[47]"),
            CardLength = 15,
            CvcLength = 4,
            MaskCC = "0000  000000  00000",
            MaskCVC = "0000",
            Order = 99
        };

        public static readonly CardLabel DISCOVER = new CardLabel
        {
            Name = "discover",
            Detector = new Regex("^6(?:011\\d{12}|5\\d{14}|4[4-9]\\d{13}|22(?:1(?:2[6-9]|[3-9]\\d)|[2-8]\\d{2}|9(?:[01]\\d|2[0-5]))\\d{10})"),
            CardLength = 16,
            CvcLength = 3,
            MaskCC = DEFAULT_CC_MASK,
            MaskCVC = DEFAULT_CVC_MASK,
            Order = 2
        };

        public static readonly CardLabel HIPERCARD = new CardLabel
        {
            Name = "hipercard",
            Detector = new Regex("^606282|384100|384140|384160"),
            CardLength = 16,
            CvcLength = 3,
            MaskCC = DEFAULT_CC_MASK,
            MaskCVC = DEFAULT_CVC_MASK,
            Order = 4
        };

        public static readonly CardLabel DINERS = new CardLabel
        {
            Name = "diners",
            Detector = new Regex("^(300|301|302|303|304|305|36|38)"),
            CardLength = 14,
            CvcLength = 3,
            MaskCC = "0000  000000  0000",
            MaskCVC = DEFAULT_CVC_MASK,
            Order = 5
        };


        public static readonly CardLabel JCB_15 = new CardLabel
        {
            Name = "jcb_15",
            Detector = new Regex("^2131|1800"),
            CardLength = 15,
            CvcLength = 3,
            MaskCC = DEFAULT_CC_MASK,
            MaskCVC = DEFAULT_CVC_MASK,
            Order = 6
        };

        public static readonly CardLabel JCB_16 = new CardLabel
        {
            Name = "jcb_16",
            Detector = new Regex("^35(?:2[89]|[3-8]\\d)"),
            CardLength = 16,
            CvcLength = 3,
            MaskCC = DEFAULT_CC_MASK,
            MaskCVC = DEFAULT_CVC_MASK,
            Order = 7
        };

        public static readonly CardLabel ELO = new CardLabel
        {
            Name = "elo",
            Detector = new Regex("^(4011(78|79)|43(1274|8935)|45(1416|7393|763(1|2))|50(4175|6699|67([0-6][0-9]|7[0-8])|9\\d{3})|627780|63(6297|6368)|650(03([^4])|04([0-9])|05(0|1)|4(0[5-9]|(1|2|3)[0-9]|8[5-9]|9[0-9])|5((3|9)[0-8]|4[1-9]|([0-2]|[5-8])\\d)|7(0\\d|1[0-8]|2[0-7])|9(0[1-9]|[1-6][0-9]|7[0-8]))|6516(5[2-9]|[6-7]\\d)|6550(2[1-9]|5[0-8]|(0|1|3|4)\\d))\\d*"),
            CardLength = 16,
            CvcLength = 3,
            MaskCC = DEFAULT_CC_MASK,
            MaskCVC = DEFAULT_CVC_MASK,
            Order = 1
        };

        public static readonly CardLabel AURA = new CardLabel
        {
            Name = "aura",
            Detector = new Regex("^((?!5066|5067|50900|504175|506699)50)"),
            CardLength = 19,
            CvcLength = 3,
            MaskCC = "0000000000000000000",
            MaskCVC = DEFAULT_CVC_MASK,
            Order = 3
        };

        #endregion
    }
}
