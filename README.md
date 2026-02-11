# Nicholas Page's Portfolio Website

A modern, responsive portfolio website built with **Blazor Server** and **ASP.NET Core**, showcasing my professional experience, education, projects, and technical skills as a software engineer and instructor.

🌐 **Live Site:** [nicholaspage.dev/](https://nicholaspage.dev/)

[![.NET](https://img.shields.io/badge/.NET-10.0-512BD4?style=flat&logo=dotnet)](https://dotnet.microsoft.com/)
[![Blazor](https://img.shields.io/badge/Blazor-Server-512BD4?style=flat&logo=blazor)](https://blazor.net/)
[![Bootstrap](https://img.shields.io/badge/Bootstrap-5-7952B3?style=flat&logo=bootstrap&logoColor=white)](https://getbootstrap.com/)
[![License](https://img.shields.io/badge/License-GPLv3-blue.svg)](LICENSE)

## 🚀 Features

### 🎨 Modern Design
- **Responsive Layout** - Optimized for all devices (desktop, tablet, mobile)
- **Dark/Light Theme Toggle** - Automatic theme switching with persistent preferences
- **Purple Gradient Accent** - Cohesive color scheme throughout (#8B5CF6 to #7C42E7)
- **Smooth Animations** - Cubic-bezier transitions and hover effects
- **Bootstrap 5 Integration** - Modern UI components and utilities

### 📄 Pages

#### 🏠 Home
- Hero section with professional headshot
- Quick stats and highlights
- Professional experience timeline
- Education overview
- Skills and interests
- Interactive call-to-action sections

#### 👤 About
- Comprehensive professional profile
- Technical skills showcase (100+ skills organized by category)
- Education details with achievements
- Certifications (AWS Cloud Practitioner, freeCodeCamp)
- Personal hobbies and interests
- Photo gallery with professional headshots

#### 💼 Experiences
- **Main Overview**: Timeline of all professional positions (5 companies, 8+ years)
- **South Hills Details**: In-depth look at current role as IT/Software Development Instructor & Software Engineer
  - 15+ courses taught
  - Custom tools developed (Grading Tools Suite, shsdp.dev platform)
  - System modernization (.NET Framework → .NET Core 10)
- Interactive cards with hover effects

#### 🎓 Education
- Bachelor of Science in Computer Science (Lock Haven University)
- Graduated Cum Laude (3.511 GPA)
- 5× Dean's List recipient
- Academic timeline with course history
- Leadership roles and achievements

#### 🚀 Activities
- Personal projects:
  - **Qt Task Manager** - Linux task manager written in C++ with Qt framework
  - **Pokeclicker Platinum** - Game development with Electron and Wayland support
- Freelance work:
  - **Gilbert & Gilbert Auctions** - PHP to ASP.NET migration with Google API integration
  - **CWD Breeding WordPress Plugin** - Custom ecommerce and database management
- Video game development experience
- Academic leadership roles

#### 📜 Credits & Licenses
- Framework and library attributions
- License information (GPLv3)
- Open-source acknowledgments

### 🛠️ Technical Features

- **Version Display** - Automatic version numbering in footer from `version.json`
- **Browser Detection** - Using Bowser.js for compatibility checking
- **Reconnection Modal** - Custom UI for SignalR connection handling
- **Responsive Navigation** - Hamburger menu on mobile with Bootstrap
- **SEO Optimized** - Proper meta tags and page titles
- **Accessibility** - ARIA labels and semantic HTML

## 🏗️ Built With

### Core Technologies
- **[.NET 10](https://dotnet.microsoft.com/)** - Latest .NET framework
- **[Blazor Server](https://blazor.net/)** - C#-based web framework
- **[ASP.NET Core](https://docs.microsoft.com/aspnet/core/)** - Web application framework
- **[Bootstrap 5](https://getbootstrap.com/)** - CSS framework
- **[Bootstrap Icons](https://icons.getbootstrap.com/)** - Icon library

### JavaScript Libraries
- **[Bowser](https://github.com/bowser-js/bowser)** - Browser detection

### Development Tools
- **[Jenkins](https://www.jenkins.io/)** - CI/CD pipelines (used at South Hills)
- **[Git](https://git-scm.com/)** - Version control
- **[Azure DevOps](https://azure.microsoft.com/services/devops/)** - Project management

## 🚀 Getting Started

### Prerequisites

- [.NET 10 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)

### Installation

1. **Clone the repository**
   ```bash
   git clone https://github.com/wheat32/portfolio-web.git
   cd portfolio-web/src/Portfolio
   ```

2. **Restore dependencies**
   ```bash
   dotnet restore
   ```

3. **Build the project**
   ```bash
   dotnet build
   ```

4. **Run the application**
   ```bash
   dotnet run
   ```

5. **Open in browser**
   Navigate to `https://localhost:5001` (or the URL shown in the console)

### Docker Support

```bash
# Build Docker image
docker build -t portfolio-web .

# Run container
docker run -p 8080:8080 portfolio-web
```

## 🎨 Customization

### Theme Colors
Edit `wwwroot/css/variables.css` to customize the color scheme:
```css
:root {
    --primary-background: #8B5CF6;  /* Purple */
    --secondary-background: #7C42E7; /* Darker purple */
    --purple-gradient: linear-gradient(90deg, #8B5CF6 0%, #7C42E7 100%);
}
```

## 📝 License

This project is licensed under the **GNU General Public License v3.0** - see the [LICENSE](LICENSE) file for details.

### Third-Party Licenses
- **ASP.NET Core** - MIT License
- **Bootstrap** - MIT License
- **Bootstrap Icons** - MIT License
- **Bowser** - MIT License

## 👨‍💻 About Me

**Nicholas E. Page**  
IT/Software Development Instructor & Software Engineer

- 🎓 B.S. in Computer Science - Lock Haven University (Cum Laude, 3.511 GPA)
- 💼 8+ years of professional software development experience
- 🏫 Teaching 15+ courses at South Hills School of Business and Technology
- 🛠️ Built custom Blazor tools for grading and student support
- 📚 Expertise in C#, ASP.NET, Java, JavaScript, Python, and more

### 🔗 Connect With Me

- 📧 Email: [nickpage3232@yahoo.com](mailto:nickpage3232@yahoo.com)
- 💼 GitHub: [@wheat32](https://github.com/wheat32)
- 📍 Location: Spring Mills, PA

### 🏆 Certifications

- **AWS Certified Cloud Practitioner** (July 2023 - July 2026)
- **Foundational C# with Microsoft** (freeCodeCamp, June 2024)
- **Relational Database Developer** (freeCodeCamp, July 2025)

## 🙏 Acknowledgments

Special thanks to the open-source community for creating and maintaining the amazing tools that made this portfolio possible:
- Microsoft ASP.NET Core Team
- Bootstrap Team
- Bootstrap Icons Contributors
- Bowser.js Maintainers

## 📊 Project Stats

- **Components**: 10+ reusable components
- **Styling**: Fully responsive with dark/light themes

---

**Built with ❤️ using Blazor and .NET 10**

*Last Updated: February 2026*

