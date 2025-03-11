# 🛒BaristaShop E-Ticaret Projesi

Bu proje, **ASP.NET Core 8.0** kullanılarak geliştirilen **mikroservis tabanlı bir e-ticaret platformudur**. **Docker, CQRS, Mediator, Ocelot API Gateway, Identity Server, MSSQL, MongoDB ve Redis** gibi modern teknolojilerle desteklenmiş, ölçeklenebilir ve güvenli bir altyapı sunmaktadır.

Projede her mikroservis bağımsız olarak geliştirilmiş ve belirli işlevlere odaklanmıştır. OrderService, Onion Mimarisi, CQRS ve Mediator tasarım desenleri ile komut ve sorguların ayrıldığı, performans odaklı bir yapıya sahiptir. 
CargoService ise N-Katmanlı Mimari ile organize edilerek klasik katmanlı yapının sunduğu modüler yapı korunmuştur. BasketService Redis ile desteklenerek sık erişilecek verilerin hızlı ve optimize edilmiş bir şekilde saklanması sağlanmıştır.
Kimlik doğrulama için Identity Server ve JWT kullanılarak güvenli giriş sağlanmıştır. 
Veritabanı seçimleri servislerin ihtiyaçlarına göre farklılık göstermektedir; MSSQL, PostgreSQL, MongoDB ve Redis kullanılarak hem ilişkisel hem de NoSQL veritabanlarıyla veri yönetimi gerçekleştirilmiştir. 
API yönetimi için Ocelot Gateway kullanılarak servisler arası iletişim sağlanmış, ölçeklenebilir bir yapı oluşturulmuştur. 
Bazı servislerde generic repository pattern kullanılırken, bazılarında iş mantığına özel repository yapıları tercih edilmiştir. 
Docker sayesinde sistemin platformdan bağımsız olarak çalışması sağlanmıştır. Önyüz geliştirme sücrecinde HTML, CSS, JavaScript ve Bootstrap ile birlikte modern ve kullanıcı dostu bir arayüze sahiptir.

## 📌 Kullanılan Teknolojiler
- **Backend:** ASP.NET Core 8.0 Web API
- **Veritabanları:** MSSQL, MongoDB, Redis, PostgreSQL
- **API Yönetimi:** Ocelot API Gateway
- **Kimlik Doğrulama:** IdentityServer4, JWT
- **Tasarım Desenleri:** CQRS, Mediator
- ORM Araçları: Entity Framework, Dapper
- **Deploy:** Docker, Portainer
- **Dokümantasyon ve Test:** Swagger, Postman
- **Önyüz:** HTML, CSS, JavaScript, Bootstrap
- **E-Posta Servisi:** MailKit

## 📦 Kurulum
### 1️⃣ Projeyi Klonlayın
```sh
git clone [https://github.com/mutucent/BaristaShop.git]
cd mikroservis-e-ticaret
```

## 📂 Proje Yapısı
```
/BaristaShop
│── Services
│   │── BasketService
│   │── CargoService
│   │── CatalogService
│   │── CommentService
│   │── DiscountService
│   │── MessageService
│   │── OrderService
│── API Gateway (Ocelot)
│── Identity Server
│── Database (MSSQL, PostgreSQL, Redis, MongoDB)
│── UI (Bootstrap, JavaScript)
│── Docs (Swagger, Postman)
```

## ✨ Geliştirme Süreci
Bu proje, Murat Yücedağ hocanın **Udemy'deki ASP.NET Core MultiShop Mikroservis E-Ticaret kursu** temel alınarak geliştirilmiştir. Projeyi oluştururken **güncel teknolojiler, mikroservis mimarisi ve SOLID prensiplerine** uygunluk hedeflenmiştir.



