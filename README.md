
# 💠 Tasbeeh HUD | عداد التسبيح

تطبيق بسيط لعدّ الأذكار باستخدام واجهة عائمة (HUD) مبنية بـ WPF في C#.

---

## 🇸🇦 بالعربي

### 🎯 المميزات

- واجهة HUD تظهر دائمًا في أعلى الشاشة.
- عداد للأذكار قابل للتخصيص.
- التنقل تلقائيًا بين الأذكار عند الانتهاء من العدد.
- ألوان متغيرة للنص لإضفاء لمسة جمالية.
- التحكم في العداد من خلال زر في لوحة المفاتيح.
- دعم التشغيل بدون الحاجة لتثبيت (مجرّد ملف .exe).

---

### 📸 صورة من التطبيق

*سيتم إضافة صورة لاحقًا*

---

### 🛠️ طريقة التشغيل للمطورين

#### المتطلبات:

- .NET 7 SDK أو أحدث  
- محرر مثل Visual Studio أو Visual Studio Code  
- دعم تطبيقات WPF  

#### خطوات التشغيل:

```
git clone https://github.com/mohamedstryker/tasbeeh-hud.git
cd tasbeeh-hud
dotnet run
```

---

### 📦 إنشاء نسخة تنفيذية (exe)

لإنشاء نسخة يمكن تشغيلها مباشرة:

```
dotnet publish -c Release -r win-x64 --self-contained true
```

ستجد الملف التنفيذي داخل المجلد:

```
bin\Release\net7.0\win-x64\publish\
```

---

### 🧠 تعديل قائمة الأذكار

يمكنك تعديل قائمة الأذكار من داخل الكود مباشرة:

```csharp
new List<(string phrase, int count)>
{
    ("سبحان الله", 33),
    ("الحمد لله", 33),
    ("الله أكبر", 34)
};
```

---

### 💡 خطط التطوير المستقبلية

- حفظ التقدّم عند الخروج.
- إمكانية تعديل الأذكار من داخل التطبيق.
- تخصيص مفتاح التسبيح من الإعدادات.
- دعم الوضع الليلي (Dark Mode).
- إشعار صوتي أو مرئي عند الانتهاء من كل ذكر.
- دعم واجهة إنجليزية بالكامل.

---

### 🙋‍♂️ المطور

Mohamed Stryker  
[GitHub Profile](https://github.com/mohamedstryker)

---

### 📝 الرخصة

MIT License – مفتوح المصدر ومتاح للاستخدام والتعديل , يرجي التعديل والتطوير جزاكم الله خيراً يا شبابنا

---

## 🇬🇧 In English

### 🎯 Features

- Always-on-top floating HUD window.
- Customizable zikr list (phrases + counts).
- Automatically switches to the next zikr after completion.
- Changing text colors for visual enhancement.
- Control via global keyboard hotkey.
- No installation required – just run the .exe.

---

### 📸 Screenshot

*Screenshot coming soon*

---

### 🛠️ How to Run (for Developers)

#### Requirements:

- .NET 7 SDK or later  
- Visual Studio or Visual Studio Code  
- WPF Desktop App Support  

#### Run the project:

```
git clone https://github.com/mohamedstryker/tasbeeh-hud.git
cd tasbeeh-hud
dotnet run
```

---

### 📦 Build Executable (.exe)

To create a standalone executable:

```
dotnet publish -c Release -r win-x64 --self-contained true
```

The executable will be located at:

```
bin\Release\net7.0\win-x64\publish\
```

---

### 🧠 Customize Zikr List

You can update the zikr list in code like this:

```csharp
new List<(string phrase, int count)>
{
    ("Subhan Allah", 33),
    ("Alhamdulillah", 33),
    ("Allahu Akbar", 34)
};
```

---

### 💡 Future Development Plans

- Save progress on exit.
- Edit zikr list via the app interface.
- Hotkey selection from settings window.
- Dark mode UI support.
- Sound or visual alert on each zikr completion.
- Full English UI support.

---

### 🙋‍♂️ Developer

Mohamed Stryker  
[GitHub Profile](https://github.com/mohamedstryker)

---

### 📃 License

MIT License – Free and open-source for personal or commercial use - please edit and develop if you want share some benefits!
