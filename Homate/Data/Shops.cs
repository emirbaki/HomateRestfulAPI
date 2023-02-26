using Homate.Models;

namespace Homate.Data
{
    public static class Shops
    {
        public static List<Shop> shops = new List<Shop>()
        {
            new Shop() { Id = 1, Name = "Hanife'nin Mekanı", Description = "Leziz Ev Yemekleri için iyi bir başlangıç"},
            new Shop() { Id = 2, Name = "Komagene Çiğköfte", Description = "Çiğköftemiz kötü ama bir sürü sos ve ekstra içerik veriyoruz."},
            new Shop() { Id = 3, Name = "Burgerye Ulan", Description = "Acıkmayın"},
            new Shop() { Id = 4, Name = "Koko Faruk", Description = "Beyaz toz harici her türlü sakatat bulunur."},
            new Shop() { Id = 5, Name = "Arby's", Description = "Bildiğin Arby's"}
        };
    }
}
