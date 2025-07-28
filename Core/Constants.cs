namespace CRM.Core
{
    // Proje genelinde kullanilacak sabit metinleri (string) burada tanimlayacagiz.
    // Bu, kodun icinde metin tekrarini onler ve bakimi kolaylastirir.
    public static class Constants
    {
        public static class Roles
        {
            public const string SuperAdmin = "Super Admin";
            public const string CEO = "CEO";
            public const string GenelMudur = "Genel Mudur";
            public const string MuhasebeMuduru = "Muhasebe Müdürü";
            public const string Muhasebe = "Muhasebe";
            public const string DepoMuduru = "Depo Muduru";
            public const string InsanKaynaklari = "İnsan Kaynakları";

        }

        public static class Sirket
        {
            // Sistemin kendisini temsil eden ozel sirketin adi.
            public const string SistemSirketiAdi = "Sistem Yönetimi";
        }
    }
}
