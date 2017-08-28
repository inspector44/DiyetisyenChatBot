Chatbot Nasıl Yapılır? Adım adım Chatbot…

Selamlar. Bugün Microsoft Bot Framework ile chatbotun nasıl yapıldığını, nasıl çalıştığını bir demo yaparak öğreneceğiz.
Chatbotumuzu dev.botframework.com sitesine giderek oluşturmamız gerekiyor. Siteye mailimiz ile giriş yaptıktan sonra hemen ana ekranda karşımıza çıkan “Create a bot or skill” i tıklayarak yeni botumuzu oluşturuyoruz. “Create Bot” ve “Register” dedikten sonra bot bilgilerimizi girmemiz gerekiyor.


Display name: Botunuzun adı. Daha sonradan değiştirilebilir.
Bot handle: Botunuzun Url’de görünen adıdır. Bu kısım önemli botunuzun türkçe karekter kullanmamaya özen gösterin. Daha sonradan değiştirilemiyor.
Long description: Botunuzu canlıya aldıktan sonra açıklama kısmında yer alan yazıdır. Botunuzu kısaca açıklamanız yeterli.

Burada botunuzu herhangi bir henüz bir servise publish etmediğiniz için “Messaging Endpoint” i boş geçerek “Create Microsoft App ID and password” butonunu tıklayarak botumuzun ID ve Password’unu alıyoruz.
Karşınıza çıkan ekranda botunuzun adını, App ID’yi ve Password’u bi not defterine kaydedin.

Bu kısmı boş geçiyoruz ve hemen altında sözleşmeyi kabul ederek “Register” diyoruz. Ve artık bir botumuz oluşmuş durumda. Artık botumuzu yazmaya başlayabiliriz.
Hızlı bir başlangıç için Microsoft Bot Framework Application Project Template i kullanabilirsiniz.
Template kurulumu için yukarıdaki adresten indirdiğiniz zip dosyasını Belgelerim > Visual Studio 201x > Templates > Project Templates > Visual C# içerisine çıkarın.
Bundan sonra proje dosyasını sizinle aşağıda paylaşmış olduğum proje üzerinden ileryeceğiz. Bu projenin nasıl çalıştığını sizlere anlatarak bir botun çalışma yapısını sunmak istiyorum.

Sıfırdan bir bot projesi açmak için gördüğünüz gibi buraya gelen hazır temlplate i kullanabiliriz. Bu template i göremediyseniz search bölümünden bot yazmanız yeterli.

Paylaşmış olduğum projeyi açtıktan sonra gördüğünüz gibi bir solution sizi karşılayacaktır. Şimdi adım adım burada neler yaptığımı size anlatacağım.

Web.Config: Burada veritabanı bağlantılarımızı ve az önce oluşturduğumuz olduğumuz botumuzla olan bağlatıları yapıyoruz. Açtıktan sonra fotoğrafta görmüş olduğunuz app settings tagini buluyoruz. Burası önemli. Az önce not defterine not aldığımız bilgileri ekranda görüldüğü gibi value’nin içine yazıyoruz. Varsa veritabanı bağlantılarımız bunuda yine connectionstring tagi içerisine yazıyoruz.

Solution’da Controller Folder’ını açtıktan sonra MessageController.cs classını göreceksiniz. Bizim botumuz bu class içerisindeki post methodu ile başlıyor. Yani botu debug etmek isterseniz ilk çalışan class bu class olacaktır. Post methodunun üstünde ve içerisinde Eventhub bağlantılarını yaptım. Orayı şimdilik görmezden gelin. Bizim botta girmiş olduğumuz messaja ait tüm bilgilerin Activity classı ile alındığını unutmayın. Nitekim gördüğünüz gibi if kontrolü içerisindede bunun controlü yapılarak aşağıda yazılan MakeBuildForm methodunu çağırıyoruz.

MakeBuildForm ile adındandan anlaşılabileceği gibi bir form yaratmak üzere geri dönüş değeri IDialog interface’i olan bir method. Models folder inda yer alan MessageModel.cs classım benim diyaloglarımı içeren class. Yani bot doğru çalıştıktan sonra işlemler bu class üzerinden yürüyor.

MessageModel classında diyalogumun olduğunu anlatmıştım. Şimdi kısaca bu uzun classı anlatmak istiyorum. Kullanıcı bir seçenek sunmak istiyorsanız. Enum yapısını kullanabilirsiniz. Özellikle form sunmak istiyorsanız enum kaçınılmaz. Ama başka bir şekilde diyalogunuzu oluşturmak istiyorsanız bu şart değil. (Card’lardan faydalanma gibi)
Not: Ben kartlara değinmeyeceğim merak edenleriniz varsa Microsoft Bot Framework Card yazarak searchleyebilir.

Sorularımıza ait propertylerimizi bu şekilde yazabiliriz. Enum kullanırken Template attribute ını kullanmamız gerekiyor.

Burada artık ekrana hangi propertylerimizi hangi sırayla basmak istedğimizi belirtiyoruz. Biliyorum kodun büyük bir bölümünü atladım fakat bunun yapmamdaki amaç size tüm kodu anlatmak değilde genel yapıyı anlatmaktı.
Herşeyi bitirdikten sonra botumuzu Azure’da paylaşabilmek için Azure’da bir web app oluşturuyoruz ve projemizi Azure’a publish ediyoruz. Daha sonrasında bize verilen endpointi dev.botframework.com’a girerek botumuzun endpointine yazıyoruz. Artık botumuz canlıda.
Skype ve Facebook’da yayımlamak için ise Channels kısmına gelerek oradan ekleyebiliyoruz. Skype’da direkt yayımlayabilirken Facebook’da bazı izinler almamız gerekiyor. Oraya bir sonraki yazıda değinmeyi düşünüyorum. Kolay gelsin :)
www.kodadam.net
