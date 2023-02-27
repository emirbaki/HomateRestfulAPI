using Homate.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Homate.Repositories.Configs
{
    public class ShopConfig : IEntityTypeConfiguration<Shop>
    {
        public void Configure(EntityTypeBuilder<Shop> builder)
        {
            builder.HasData(
            new Shop() { Id = 1, Name = "Hanife'nin Mekanı", Description = "Leziz Ev Yemekleri için iyi bir başlangıç" },
            new Shop() { Id = 2, Name = "Komagene Çiğköfte", Description = "Çiğköftemiz kötü ama bir sürü sos ve ekstra içerik veriyoruz." },
            new Shop() { Id = 3, Name = "Burgerye Ulan", Description = "Acıkmayın" },
            new Shop() { Id = 4, Name = "Koko Faruk", Description = "Beyaz toz harici her türlü sakatat bulunur." },
            new Shop() { Id = 5, Name = "Arby's", Description = "Bildiğin Arby's" },
            new Shop() { Id = 6, Name = "Kopernik Pizza", Description = "Dünyanın en sıcak pizzası" }
            );
        }
    }
}
