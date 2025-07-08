# CompanySubmission

CompanySubmission adalah project ASP.NET Core 8 yang terdiri dari:

- ✅ **Web API** untuk menerima dan menyimpan data perusahaan serta file dokumen (NPWP & Power of Attorney)
- ✅ **MVC Client** untuk form pengisian data
- ✅ **SQL Server** sebagai database
- ✅ Upload file dokumen ke folder `/wwwroot/uploads/{NPWP/Power}/{CompanyId}`

---

## 🚀 Fitur

- Form input Company Name, NPWP, Director Name, PIC Name, Email, Phone Number
- Upload file dokumen NPWP dan Surat Kuasa (Power of Attorney)
- Validasi: field alfanumerik + wajib centang izin
- File tersimpan dengan struktur `wwwroot/uploads/{NPWP/Power}/{CompanyId}/`

---

## 🔧 Teknologi

- .NET 8 (ASP.NET Core Web API & MVC)
- SQL Server
- Entity Framework Core
- Bootstrap 4
- jQuery + Unobtrusive Validation

---

## 🧱 Setup Database

# Masuk ke proyek API
```bash
cd CompanySubmission.API
```

# Tambahkan migration
```bash
dotnet ef migrations add InitialCreate
```

# Terapkan ke database
```bash
dotnet ef database update
```


## 📁 Struktur Proyek

```plaintext
CompanySubmission/
│
├── CompanySubmission.API/       # Proyek Web API (.NET 8)
│   ├── Controllers/
│   ├── Data/
│   ├── Models/
│   └── Program.cs
│
├── CompanySubmission.MVC/       # Proyek ASP.NET MVC
│   ├── Controllers/
│   ├── Models/
│   ├── Views/
│   └── Program.cs
│
└── README.md
