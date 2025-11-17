using JaemyPortfolio.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace JaemyPortfolio.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Apply pending migrations (creates database if it doesn't exist)
            context.Database.Migrate();

            // Seed Portfolio Items
            if (!context.PortfolioItems.Any())
            {
                var portfolioItems = new PortfolioItem[]
                {
                    new PortfolioItem
                    {
                        Title = "JaemyHo.com - Personal Portfolio Website",
                        Description = "A humble portfolio website built with C# ASP.NET to showcase professional experience, resume, and projects. Features a responsive design with hero section, navigation, and contact information. Hosted on GoDaddy.com with integrated expense tracking system and future plans for admin panel and OCR receipt scanning.",
                        Technologies = "C# ASP.NET, Bootstrap, HTML5, CSS3, JavaScript",
                        ProjectUrl = "https://jaemyho.com",
                        GitHubUrl = "#",
                        ImageUrl = "~/images/portfolio/jaemyho-website.jpg",
                        CreatedAt = new DateTime(2024, 1, 1),
                        IsActive = true
                    },
                    new PortfolioItem
                    {
                        Title = "Stock Broking System - Excel Force MSC",
                        Description = "Cutting-edge online trading solution for viewing live stock feeds, buying/selling stocks, and analyzing technical charts. Developed as part of CyberBroker Front Office systems including BTX (Bridging Trader & Exchange), CyberStock Ecos, and WebEcos. Features real-time stock quotations, order management, and integration with Bursa Malaysia for stock feeds.",
                        Technologies = "C++, C# ASP.NET, GDI+, OCX, SQL Server, Bursa Malaysia API",
                        ProjectUrl = "#",
                        GitHubUrl = "#",
                        ImageUrl = "~/images/portfolio/stock-broking-system.jpg",
                        CreatedAt = new DateTime(2018, 6, 1),
                        IsActive = true
                    },
                    new PortfolioItem
                    {
                        Title = "ExpenseMate - Expense Tracking Application",
                        Description = "Comprehensive expense-tracking application developed in Python as part of a group assignment for the Master of Software Engineering at Yoobee College, utilizing Agile development principles. Features dynamic dashboard with spending trends visualization, category breakdowns, receipt OCR processing, and detailed audit logging for transparency and accountability.",
                        Technologies = "Python, Flask, OCR, Data Visualization, Agile Development",
                        ProjectUrl = "#",
                        GitHubUrl = "#",
                        ImageUrl = "~/images/portfolio/expensemate.jpg",
                        CreatedAt = new DateTime(2024, 10, 1),
                        IsActive = true
                    },
                    new PortfolioItem
                    {
                        Title = "Financial Back Office System",
                        Description = "Automated and optimized back-office operations solution that maintains system integrity for trade processing and settlement. Successfully led the conversion of a Singapore-based financing bank's traditional Windows back-office application to a modern web-based ASP.NET platform, significantly improving accessibility, efficiency, and user experience.",
                        Technologies = "C# ASP.NET, Windows Migration, Financial Systems, Trade Processing",
                        ProjectUrl = "#",
                        GitHubUrl = "#",
                        ImageUrl = "~/images/portfolio/financial-back-office.jpg",
                        CreatedAt = new DateTime(2021, 3, 1),
                        IsActive = true
                    },
                    new PortfolioItem
                    {
                        Title = "TimeTac Patrol - Security Management System",
                        Description = "Security management solution leveraging NFC, BLE, and cloud computing to streamline patrol operations and enhance real-time reporting for security personnel. Successfully enhanced the Patrol System by integrating Google Maps API with geofence technology, improving geolocation accuracy and functionality. Developed APIs for mobile application communication.",
                        Technologies = "C# ASP.NET, NFC, BLE, Cloud Computing, Google Maps API, Geofencing",
                        ProjectUrl = "#",
                        GitHubUrl = "#",
                        ImageUrl = "~/images/portfolio/timetac-patrol.jpg",
                        CreatedAt = new DateTime(2020, 2, 1),
                        IsActive = true
                    },
                    new PortfolioItem
                    {
                        Title = "Multi Foreign Share Trading System",
                        Description = "Enhanced legacy system to enable foreign stock trading with integrated stock market feeds from USA, Hong Kong, and Singapore. Extended the existing CyberStock Bridging Trader & Exchange System using APIs to provide comprehensive international trading capabilities. Focused on improving system functionality and meeting client requirements for global market access.",
                        Technologies = "C++, API Integration, Stock Market Feeds, Foreign Trading, Legacy System Enhancement",
                        ProjectUrl = "#",
                        GitHubUrl = "#",
                        ImageUrl = "~/images/portfolio/foreign-trading.jpg",
                        CreatedAt = new DateTime(2019, 8, 1),
                        IsActive = true
                    }
                };

                foreach (PortfolioItem item in portfolioItems)
                {
                    context.PortfolioItems.Add(item);
                }
                context.SaveChanges();
            }
        }
    }
}
