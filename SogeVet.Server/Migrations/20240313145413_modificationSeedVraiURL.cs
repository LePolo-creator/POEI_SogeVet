using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SogeVet.Server.Migrations
{
    /// <inheritdoc />
    public partial class modificationSeedVraiURL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Color", "Description", "Images", "Name" },
                values: new object[] { "Bleu", "Veste Bleu costard", "[\"https://www.angledelamode.com/public/img/big/IMG9218jpeg_6436b12ec91ee.jpeg\",\"https://mobile.yoox.com/images/items/49/49867134XU_14_f.jpg?impolicy=crop\\u0026width=387\\u0026height=490\",\"https://static.fursac.com/data/cache/LandingPage/picture/main/f/f/306.1606245987.jpg\"]", "Veste Bleu" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Color", "Description", "Images", "Name" },
                values: new object[] { "Jaune", "Robe jaune avec pois", "[\"https://www.tendance-retro.fr/cdn/shop/products/robe-jaune-a-pois-style-pin-up-284_1200x1200.jpg?v=1657442970\",\"https://robe-fleurie.fr/cdn/shop/products/H9158b11ff7f7490d9163393b8e0fdd522_1500x1500.jpg?v=1655929435\",\"https://www.oksana-mukha.fr/wp-content/uploads/2021/05/robe-de-cocktail-jaune-vif.jpg\"]", "Robe Jaune" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Images", "Name" },
                values: new object[] { "[\"https://www.sao-bio.fr/6260-large_default/short-bebe-coton-bio-rayures-bleues.jpg\",\"https://www.saisondesabeilles.fr/wp-content/uploads/Saison-des-Abeilles-Vetements-enfants-Habillement-bebe-coton-biologique-garcon-fille-short-bleu-fonce1.jpg\"]", "Short Bleu" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Color", "Images", "Name" },
                values: new object[] { "Vert", "[\"https://www.tee-shirt-publicitaire-pro.com/images/tee-shirt-publicitaire/large/t-shirt-publicitaire-fotoco-pour-enfant-vert_kelly_2.jpg\",\"https://www.ekinsport.com/media/catalog/product/cache/173ef9ab000c6667578594f63bf9da15/c/z/cz0909-302_t-shirt-nike-team-club-20-vert-pour-enfant-cz0909-302_01.jpg\",\"https://www.crafters.fr/images/stories/virtuemart/tt2016/PS_GI5000B_IRISHGREEN.jpg\"]", "t shirt enfant vert" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Color", "Images", "Name" },
                values: new object[] { "Violet", "[\"https://www.basket-sucy.fr/wp-content/uploads/2022/09/des-petit-hauts-tee-shirt-frizon-violet-violet-t-shirts-tops-femme.jpg\",\"https://www.lagentlefactory.com/img/p/1/1/3/0/8/11308-medium_default.jpg\"]", "tshirt femme violet" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Color", "Images", "Name" },
                values: new object[] { "Vert", "[\"https://image1.superdry.com/static/images/optimised/zoom/upload9223368955666328142.jpg\",\"https://images.asos-media.com/products/selected-homme-pantalon-cargo-vert-fonce/12511990-4?$n_640w$\\u0026wid=513\\u0026fit=constrain\",\"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSCQAO8ogt8GohpJASx9VtsSwr8_HgHFKFPV25Z5TQ3WA\\u0026s\",\"https://www.boutique-militaire.fr/cdn/shop/products/pantalon-cargo-vert-kaki-homme-boutique-militaire_600x600.jpg?v=1650033892\"]", "pantalon homme cargo" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Color", "Images", "Name" },
                values: new object[] { "Noir", "[\"https://www.cdiscount.com/pdt2/6/4/4/3/700x700/mp135295644/rw/pull-femme-en-tricot-col-v-avec-boutons-manches-lo.jpg\",\"https://www.cdiscount.com/pdt2/5/0/6/1/700x700/mp128602506/rw/pull-femme-en-tricot-court-col-arrondi-manches-lon.jpg\",\"https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSw9Ai1-uVO7dPC98wUI9hKs59CA7q4PHsnZrCEii3nwg\\u0026s\"]", "pull femme hiver noir" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Color", "Images", "Name" },
                values: new object[] { "Bleu", "[\"https://lp2.hm.com/hmgoepprod?set=quality%5B79%5D%2Csource%5B%2F30%2F93%2F30930506ba1409bdaf7eeddbeed199f7ac5b1783.jpg%5D%2Corigin%5Bdam%5D%2Ccategory%5Bkids_boys_clothing_jumperssweatshirts_hoodies%5D%2Ctype%5BDESCRIPTIVESTILLLIFE%5D%2Cres%5Bm%5D%2Chmver%5B2%5D\\u0026call=url[file:/product/main]\",\"https://www.brise-lames.com/3452-large_default/gilet-capuche-en-molleton-raye-ecrumarine-enfant.jpg\"]", "Veste enfant rayé" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Color", "Images", "Name" },
                values: new object[] { "Bleu", "[\"https://www.americanvintage-store.com/dw/image/v2/BGNV_PRD/on/demandware.static/-/Sites-master-catalog/default/dw8bf99e72/images/productPictures/E23/MODU09AE23/MODU09AE23-RAYBLEU-MODEL-4-large.jpg?sw=720\\u0026sh=1125\",\"https://cdn.monsieurtshirt.com/images/87908/product_list/filgood-l-homme-ideal-cocarde-brode.jpg?1627899944000\"]", "Short de bain rayé homme" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Color", "Images", "Name" },
                values: new object[] { "Jaune", "[\"https://www.petitspinpins.com/1997-large_default/bavoir-bebe-raton-laveur-jaune.jpg\",\"https://www.ludilabel.fr/media/catalog/product/cache/1/image/1800x/040ec09b1e35df139433887a97daa66f/p/a/packshot-bavoir-trixie-mr-lion-bib.jpg\"]", "Bavoir bébé" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Color", "Images", "Name" },
                values: new object[] { "Marron", "[\"https://cdn1.incorio.com/3034-large_default/chaussettes-fil-decosse-marron.jpg\",\"https://www.boulevard-dore.fr/44840-large_default/chaussettes-homme-soft-cotton-marron.jpg\"]", "Chaussettes marron" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Images", "Name" },
                values: new object[] { "[\"https://www.cdiscount.com/pdt2/9/2/5/1/700x700/mp61405925/rw/collant-femme-hiver-thermiques-collan-double-polai.jpg\",\"https://www.collantfemme.fr/355-large_default/collant-noir-fantaisie-fleuri-mila.jpg\",\"https://jambissima.fr/media/cache/w_500/6d/71/3a0b95e82b4318056b84ba521639.jpg\"]", "Collant Femme" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Color", "Description", "Images", "Name" },
                values: new object[] { "Blanc", "Description du produit 1", "[\"URL1.1\",\"URL1.2\",\"URL1.3\"]", "Produit 1" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Color", "Description", "Images", "Name" },
                values: new object[] { "Noir", "Description du produit 2", "[\"URL2.1\",\"URL2.2\",\"URL2.3\"]", "Produit 2" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Images", "Name" },
                values: new object[] { "[\"URL3.1\",\"URL3.2\",\"URL3.3\"]", "Produit 3" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Color", "Images", "Name" },
                values: new object[] { "Rouge", "[\"URL4.1\",\"URL4.2\",\"URL4.3\"]", "Produit 4" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Color", "Images", "Name" },
                values: new object[] { "Vert", "[\"URL5.1\",\"URL5.2\",\"URL5.3\"]", "Produit 5" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Color", "Images", "Name" },
                values: new object[] { "Bleu", "[\"URL6.1\",\"URL6.2\",\"URL6.3\"]", "Produit 6" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Color", "Images", "Name" },
                values: new object[] { "Violet", "[\"URL7.1\",\"URL7.2\",\"URL7.3\"]", "Produit 7" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Color", "Images", "Name" },
                values: new object[] { "Vert", "[\"URL8.1\",\"URL8.2\",\"URL8.3\"]", "Produit 8" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Color", "Images", "Name" },
                values: new object[] { "Marron", "[\"URL9.1\",\"URL9.2\",\"URL9.3\"]", "Produit 9" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Color", "Images", "Name" },
                values: new object[] { "Turquoise", "[\"URL10.1\",\"URL10.2\",\"URL10.3\"]", "Produit 10" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Color", "Images", "Name" },
                values: new object[] { "Vert", "[\"URL11.1\",\"URL11.2\",\"URL11.3\"]", "Produit 11" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Images", "Name" },
                values: new object[] { "[\"URL12.1\",\"URL12.2\",\"URL12.3\"]", "Produit 12" });
        }
    }
}
