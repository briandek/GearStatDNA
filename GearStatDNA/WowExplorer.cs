using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace GearStatDNA
{
    public enum Region
    {
        US,
        Europe,
        Korea,
        Taiwan,
        China
    }

    public enum Locale
    {
        None,
        en_US,
        es_MX,
        pt_BR,
        en_GB,
        es_ES,
        fr_FR,
        fu_RU,
        de_DE,
        pt_PT,
        it_IT,
        ko_KR,
        zh_TW,
        zh_CN
    }

    [Flags]
    public enum CharacterDetails
    {
        None = 0,
        Achievements = 1,
        Appearance = 2,
        Feed = 4,
        Guild = 8,
        HunterPets = 16,
        Items = 32,
        Mounts = 64,
        Pets = 128,
        PetSlots = 256,
        Professions = 512,
        Progression = 1024,
        PvP = 2048,
        Quests = 4096,
        Reputation = 8192,
        Stats = 16384,
        Talents = 32768,
        Titles = 65536,
        All = Achievements | Appearance | Feed | Guild | HunterPets | Items | Mounts
            | Pets | PetSlots | Professions | Progression | PvP | Quests | Reputation | Stats
            | Talents | Titles
    }

    public class WowExplorer
    {
        public string Host { get; set; }
        public Region Region { get; set; }
        public Locale Locale { get; set; }

        private string Fields { get; set; }

        private string publicAuthKey { get; set; }
        private string privateAuthKey { get; set; }

        public WowExplorer()
            : this(Region.US, Locale.en_US)
        {
        }

        public WowExplorer(Region region)
            : this(region, Locale.None)
        {
        }

        public WowExplorer(Region region, Locale locale, string publicAuthKey, string privateAuthKey)
            : this(region, locale)
        {
            this.publicAuthKey = publicAuthKey;
            this.privateAuthKey = privateAuthKey;
        }

        public WowExplorer(Region region, Locale locale)
        {
            if (locale != Locale.None) Locale = locale;

            switch (region)
            {
                case Region.Europe:
                    if (locale == Locale.None) Locale = Locale.en_GB;
                    Host = "eu.battle.net";
                    break;
                case Region.Korea:
                    if (locale == Locale.None) Locale = Locale.ko_KR;
                    Host = "kr.battle.net";
                    break;
                case Region.Taiwan:
                    if (locale == Locale.None) Locale = Locale.zh_TW;
                    Host = "tw.battle.net";
                    break;
                case Region.China:
                    if (locale == Locale.None) Locale = Locale.zh_CN;
                    Host = "www.battlenet.com.cn";
                    break;
                case Region.US:
                default:
                    if (locale == Locale.None) Locale = Locale.en_US;
                    Host = "us.battle.net";
                    break;
            }
        }

        public void SetAuthentication(string publicAuthKey, string privateAuthKey)
        {
            this.publicAuthKey = publicAuthKey;
            this.privateAuthKey = privateAuthKey;
        }

        public Character GetCharacterDetails(string realm, string name)
        {
            return GetCharacterDetails(realm, name, CharacterDetails.All);
        }

        public Character GetCharacterDetails(string realm, string name, CharacterDetails details)
        {
            Fields = buildCharacterOptionalQuery(details);
            string URL = string.Format(@"https://{0}/api/wow/character/{1}/{2}?locale={3}{4}", Host, realm, name, Locale, Fields);
            return BuildObjectFromJsonURL<Character>(URL);
        }

        public Item GetItemDetails(int id)
        {
            string URL = string.Format(@"https://{0}/api/wow/item/{1}?locale={2}", Host, id, Locale);
            return BuildObjectFromJsonURL<Item>(URL);
        }

        public T BuildObjectFromJsonURL<T>(string url) where T : class
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            string json = GetJsonString(url);
            return js.Deserialize<T>(json);
        }

        public string GetJsonString(string url)
        {
            HttpWebRequest req = WebRequest.Create(url) as HttpWebRequest;

            if (!string.IsNullOrEmpty(privateAuthKey) && !string.IsNullOrEmpty(publicAuthKey))
            {
                DateTime date = DateTime.Now.ToUniversalTime();
                req.Date = date;

                string stringToSign =
                    req.Method + "\n"
                    + date.ToString("r") + "\n"
                    + req.RequestUri.AbsolutePath + "\n";

                byte[] buffer = Encoding.UTF8.GetBytes(stringToSign);

                HMACSHA1 hmac = new HMACSHA1(Encoding.UTF8.GetBytes(privateAuthKey));

                string signature = Convert.ToBase64String(hmac.ComputeHash(buffer));

                req.Headers[HttpRequestHeader.Authorization]
                    = "BNET " + publicAuthKey + ":" + signature;
            }
            HttpWebResponse res = req.GetResponse() as HttpWebResponse;

            using (StreamReader streamReader = new StreamReader(res.GetResponseStream(), Encoding.UTF8))
            {
                return streamReader.ReadToEnd();
            }
        }

        private string buildCharacterOptionalQuery(CharacterDetails CharacterDetails)
        {
            string query = "&fields=";
            List<string> tmp = new List<string>();

            if ((CharacterDetails & CharacterDetails.Achievements) == CharacterDetails.Achievements)
                tmp.Add("achievements");

            if ((CharacterDetails & CharacterDetails.Appearance) == CharacterDetails.Appearance)
                tmp.Add("appearance");

            if ((CharacterDetails & CharacterDetails.Feed) == CharacterDetails.Feed)
                tmp.Add("feed");

            if ((CharacterDetails & CharacterDetails.Guild) == CharacterDetails.Guild)
                tmp.Add("guild");

            if ((CharacterDetails & CharacterDetails.HunterPets) == CharacterDetails.HunterPets)
                tmp.Add("hunterPets");

            if ((CharacterDetails & CharacterDetails.Items) == CharacterDetails.Items)
                tmp.Add("items");

            if ((CharacterDetails & CharacterDetails.Mounts) == CharacterDetails.Mounts)
                tmp.Add("mounts");

            if ((CharacterDetails & CharacterDetails.Pets) == CharacterDetails.Pets)
                tmp.Add("pets");

            if ((CharacterDetails & CharacterDetails.PetSlots) == CharacterDetails.PetSlots)
                tmp.Add("petSlots");

            if ((CharacterDetails & CharacterDetails.Professions) == CharacterDetails.Professions)
                tmp.Add("professions");

            if ((CharacterDetails & CharacterDetails.Progression) == CharacterDetails.Progression)
                tmp.Add("progression");

            if ((CharacterDetails & CharacterDetails.PvP) == CharacterDetails.PvP)
                tmp.Add("pvp");

            if ((CharacterDetails & CharacterDetails.Quests) == CharacterDetails.Quests)
                tmp.Add("quests");

            if ((CharacterDetails & CharacterDetails.Reputation) == CharacterDetails.Reputation)
                tmp.Add("reputation");

            if ((CharacterDetails & CharacterDetails.Stats) == CharacterDetails.Stats)
                tmp.Add("stats");

            if ((CharacterDetails & CharacterDetails.Talents) == CharacterDetails.Talents)
                tmp.Add("talents");

            if ((CharacterDetails & CharacterDetails.Titles) == CharacterDetails.Titles)
                tmp.Add("titles");

            if (tmp.Count == 0) return string.Empty;

            query += string.Join(",", tmp.ToArray());

            return query;
        }
    }
}
