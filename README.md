یک سیستم کامل مدیریت اخبار با معماری مدرن Onion و تکنولوژی‌های روز
✨ ویژگی‌های کلیدی
✅ معماری Clean/Onion با ۴ لایه مجزا

✅ سیستم احراز هویت با نقش‌های Admin/User

✅ پنل مدیریت اخبار (CRUD کامل)

✅ Entity Framework Core با روش Code-First

✅ پشتیبانی از SQL Server LocalDB

✅ صفحات Razor با طرح‌بندی ریسپانسیو

✅ سیستم انتشار هوشمند (پیش‌نویس/منتشر شده)

🛠️ فناوری‌های استفاده شده
بخش	تکنولوژی‌ها
Backend	.NET 8, EF Core 8, Identity, Dependency Injection
Frontend	Razor Pages, Bootstrap 5, jQuery Validation
Database	SQL Server LocalDB
معماری	Onion Architecture + Repository Pattern + Unit of Work
🚀 راه‌اندازی پروژه
پیش‌نیازها:

Visual Studio 2022

.NET 8 SDK

SQL Server LocalDB

نصب و اجرا:

bash
# کلون کردن پروژه
git clone https://github.com/yourusername/NewsPortal.git
cd NewsPortal

# باز کردن در ویژوال استودیو
start NewsPortal.sln

# اجرای مهاجرت‌های دیتابیس (در Package Manager Console)
Add-Migration InitialCreate -StartupProject NewsPortal.Web -Project NewsPortal.Infrastructure
Update-Database -StartupProject NewsPortal.Web -Project NewsPortal.Infrastructure
حساب‌های پیش‌فرض:

ادمین: admin@news.local / Admin@123

کاربر عادی: از طریق ثبت‌نام ایجاد شود

📂 ساختار پروژه
text
NewsPortal/
├─ NewsPortal.Domain/        # لایه دامنه
│  ├─ Entities/             # موجودیت‌ها
│  └─ Abstractions/         # اینترفیس‌های پایه
│
├─ NewsPortal.Application/  # لایه منطق کسب‌وکار
│  ├─ Contracts/            # اینترفیس‌های سرویس‌ها
│  └─ DTOs/                 # مدل‌های انتقال داده
│
├─ NewsPortal.Infrastructure/ # لایه زیرساخت
│  ├─ Identity/             # تنظیمات Identity
│  ├─ Persistence/          # پیاده‌سازی EF Core
│  └─ Services/             # پیاده‌سازی سرویس‌ها
│
└─ NewsPortal.Web/          # لایه ارائه
   ├─ Areas/                # پنل مدیریت
   ├─ Pages/                # صفحات Razor
   └─ wwwroot/              # فایل‌های استاتیک
🤝 مشارکت در پروژه
مشارکت‌های شما باعث بهبود این پروژه می‌شود:

پروژه را Fork کنید

یک Branch جدید ایجاد کنید (git checkout -b feature/your-feature)

تغییرات را Commit کنید (git commit -m 'Add some feature')

تغییرات را Push کنید (git push origin feature/your-feature)

یک Pull Request باز کنید

📜 مجوز
این پروژه تحت مجوز MIT منتشر شده است. برای اطلاعات بیشتر فایل LICENSE را مطالعه کنید.

📞 تماس با من
اگر سوال یا پیشنهادی دارید، خوشحال می‌شوم از طریق ایمیل با من در ارتباط باشید:
✉️edris1385hoseini@gmail.com
