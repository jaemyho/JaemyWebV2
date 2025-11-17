# Jaemy Ho Portfolio Website

A modern, responsive portfolio website built with ASP.NET MVC showcasing professional experience, projects, and blog posts.

## 🛠️ Technology Stack

### Frontend
- **ASP.NET MVC** - Server-side web framework
- **Razor View Engine** - For generating HTML
- **Bootstrap 5** - Responsive CSS framework
- **jQuery** - JavaScript library for enhanced interactions
- **Font Awesome** - Icons and graphics

### Backend
- **C# ASP.NET MVC** - Core application framework
- **Entity Framework Core** - ORM for database operations
- **ASP.NET Identity** - Authentication and authorization
- **Dependency Injection** - Built-in DI container
- **Serilog** - Structured logging library

### Database
- **MySQL** - Primary database engine

## 🚀 Features

- **Responsive Design** - Mobile-friendly across all devices
- **Modern UI/UX** - Clean, professional appearance with animations
- **Portfolio Showcase** - Display projects with filtering and details
- **Blog System** - Share insights and technical articles
- **Contact Form** - Interactive contact system with validation
- **Resume Display** - Professional resume with downloadable PDF
- **Authentication** - User login/logout functionality
- **SEO Optimized** - Meta tags and structured content

## 📋 Prerequisites

Before running this project, ensure you have the following installed:

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)
- [MySQL Server](https://dev.mysql.com/downloads/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/) or [Visual Studio Code](https://code.visualstudio.com/)

## 🔧 Setup Instructions

### 1. Clone the Repository
```bash
git clone [repository-url]
cd JaemyWebV2
```

### 2. Database Configuration
1. Create a MySQL database named `JaemyPortfolioDB`
2. Update the connection string in `appsettings.json`:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=JaemyPortfolioDB;User=root;Password=yourpassword;"
  }
}
```

### 3. Install Dependencies
```bash
dotnet restore
```

### 4. Database Migration
```bash
dotnet ef database update
```

### 5. Run the Application
```bash
dotnet run
```

The application will be available at `https://localhost:5001` (HTTPS) or `http://localhost:5000` (HTTP).

## 📁 Project Structure

```
JaemyWebV2/
├── Areas/
│   └── Identity/          # ASP.NET Identity pages
├── Controllers/           # MVC Controllers
│   ├── HomeController.cs
│   ├── ResumeController.cs
│   ├── PortfolioController.cs
│   ├── ContactController.cs
│   └── BlogController.cs
├── Data/                 # Data access layer
│   ├── ApplicationDbContext.cs
│   └── DbInitializer.cs
├── Models/               # Entity models
│   ├── ContactMessage.cs
│   ├── BlogPost.cs
│   ├── PortfolioItem.cs
│   ├── HomeViewModel.cs
│   └── ErrorViewModel.cs
├── Views/                # Razor views
│   ├── Home/
│   ├── Resume/
│   ├── Portfolio/
│   ├── Contact/
│   ├── Blog/
│   └── Shared/
├── wwwroot/              # Static files
│   ├── css/
│   ├── js/
│   └── lib/
├── Program.cs            # Application entry point
└── appsettings.json      # Configuration
```

## 🎨 Key Pages

### Home Page (`/`)
- Hero section with introduction
- Featured projects showcase
- Technical skills overview
- Latest blog posts preview

### Resume Page (`/Resume`)
- Professional summary
- Work experience timeline
- Education and certifications
- Skills and technologies
- Downloadable resume PDF

### Portfolio Page (`/Portfolio`)
- Project gallery with filtering
- Detailed project views
- Technology badges
- Live demo and GitHub links

### Contact Page (`/Contact`)
- Interactive contact form with validation
- Contact information
- Social media links
- Service offerings

### Blog Page (`/Blog`)
- Article listing with pagination
- Detailed blog post views
- Categories and tags
- Newsletter subscription

## 🔒 Authentication

The application includes ASP.NET Identity for user management:

- **Login Page**: `/Identity/Account/Login`
- **Registration**: `/Identity/Account/Register`
- **Password Recovery**: Available through Identity pages

## 📊 Database Schema

### Core Tables
- `AspNetUsers` - User authentication (Identity)
- `ContactMessages` - Contact form submissions
- `BlogPosts` - Blog articles and content
- `PortfolioItems` - Project portfolio entries

## 🎯 Customization

### Adding New Portfolio Projects
1. Access the admin interface (requires authentication)
2. Navigate to portfolio management
3. Add project details: title, description, images, technologies, links

### Creating Blog Posts
1. Log into the administrative interface
2. Navigate to blog management
3. Create new posts with title, content, tags, and publication status

### Styling Changes
- Modify `wwwroot/css/site.css` for custom styling
- Update Bootstrap themes in the layout file
- Customize color schemes using CSS variables

## 📝 Logging

The application uses Serilog for structured logging:

- **Console Output**: Development logging
- **File Logging**: Permanent log storage (`logs/` directory)
- **Configurable Levels**: Informational, Warning, Error levels

Log files are automatically rotated daily and stored in the `logs/` directory.

## 🚀 Deployment

### Production Setup
1. Update `appsettings.Production.json` with production connection strings
2. Configure proper logging levels for production
3. Set up SSL certificates for HTTPS
4. Configure reverse proxy (Nginx/Apache) for production hosting

### Environment Variables
Set the following environment variables for production:
- `ASPNETCORE_ENVIRONMENT=Production`
- `ConnectionStrings__DefaultConnection=[production-connection-string]`

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch (`git checkout -b feature/AmazingFeature`)
3. Commit your changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request

## 📦 Dependencies

### NuGet Packages
- `Microsoft.AspNetCore.Identity.EntityFrameworkCore` - Identity management
- `Microsoft.EntityFrameworkCore.Design` - EF Core tools
- `Pomelo.AspNetCore.Identity.EntityFrameworkCore` - MySQL provider
- `Serilog.AspNetCore` - Structured logging

## 📞 Support

For support and questions:
- Email: contact@jaemyho.com
- Create an issue in this repository
- Visit the contact page at `/Contact`

## 📄 License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

## 🙏 Acknowledgments

- Bootstrap team for the excellent CSS framework
- ASP.NET team for the robust MVC framework
- Font Awesome for the comprehensive icon library
- The .NET community for continuous support and innovation