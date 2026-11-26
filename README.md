# Social Business PRO: app móvil Xamarin.Forms para una red social de negocios

[![Xamarin.Forms](https://img.shields.io/badge/Xamarin.Forms-4.6-3498DB?logo=xamarin&logoColor=white)](https://dotnet.microsoft.com/apps/xamarin/xamarin-forms)
[![C#](https://img.shields.io/badge/C%23-XAML-239120?logo=csharp&logoColor=white)](https://learn.microsoft.com/dotnet/csharp/)
[![Android](https://img.shields.io/badge/Android-API%2019%2B-3DDC84?logo=android&logoColor=white)](https://developer.android.com/)
[![iOS](https://img.shields.io/badge/iOS-Xamarin.iOS-000000?logo=apple&logoColor=white)](https://learn.microsoft.com/xamarin/ios/)
[![Google Maps](https://img.shields.io/badge/Mapas-Google%20Maps-4285F4?logo=googlemaps&logoColor=white)](https://developers.google.com/maps)
[![Estado](https://img.shields.io/badge/estado-archivo%20hist%C3%B3rico-lightgrey)](#estado-del-proyecto)

Aplicación móvil multiplataforma (Android, iOS y UWP) para una red social de negocios donde inmobiliarias, constructoras, franquicias, asociaciones y profesionales publican ofertas, organizan eventos, se califican en rankings y se contactan por chat y mapas.

## Qué problema resuelve

Reúne en una sola app a los actores de un sector de negocios (oferta, demanda y asociaciones) para que se encuentren por ubicación, publiquen y busquen ofertas, y construyan reputación con reseñas, logros y rankings.

## Funcionalidades

- **Cuenta**: registro, inicio de sesión, recuperación y cambio de contraseña, perfil propio y de otros usuarios.
- **Búsqueda**: perfiles, profesionales, inmobiliarias, franquicias y ofertas, con filtros.
- **Ofertas**: crear, editar y consultar ofertas propias y de una inmobiliaria.
- **Inmobiliarias y constructoras**: alta, administración y sus ofertas.
- **Asociaciones y equipo**: consulta de asociaciones y de los miembros del equipo.
- **Eventos**: eventos próximos, mis eventos e histórico.
- **Reputación**: comentarios, reseñas, logros y rankings.
- **Mapas**: ubicación en mapa con Google Maps y guardado de la ubicación.
- **MLS y chat**: sección de listado compartido y navegador de chat integrado.

## Estado del proyecto

Proyecto de 2020 mantenido como archivo histórico. Xamarin.Forms llegó al fin de soporte en 2024, por lo que compilarlo hoy requiere un entorno de la época (por ejemplo Visual Studio 2019 con las cargas de trabajo de Xamarin).

## Estructura

```
.
├── Social Business PRO.sln
├── SocialBusinessApp/
│   ├── SocialBusinessApp/            # Proyecto compartido (Xamarin.Forms)
│   │   ├── Views/                    # Páginas XAML (84 archivos)
│   │   ├── Tabbeds/                  # Navegación con pestañas
│   │   ├── Cells/                    # Celdas de listas
│   │   ├── Models/                   # Modelos de datos
│   │   ├── ViewModels/
│   │   ├── Services/                 # Interfaces de servicios de plataforma
│   │   └── Behaviors/
│   ├── SocialBusinessApp.Android/    # Proyecto Android (minSdk 19, targetSdk 28)
│   ├── SocialBusinessApp.iOS/        # Proyecto iOS
│   └── SocialBusinessApp.UWP/        # Proyecto UWP
├── IOS/                              # Recursos de iOS
└── Imagenes SB/, Imagenes SB2/       # Recursos gráficos de la marca
```

## Requisitos

- Visual Studio 2019 con las cargas de trabajo de **Desarrollo móvil con .NET** (Xamarin) y, para iOS, un equipo Mac para compilar.
- Una llave de la API de Google Maps (Android e iOS).

## Ejecución local

1. Clona el repositorio y ábrelo:

   ```bash
   git clone git@github.com:KevinAndrey96/sb-app.git
   ```

   Abre `Social Business PRO.sln` en Visual Studio y restaura los paquetes NuGet (el archivo `.gitignore` excluye la carpeta `packages/`).

2. Configura tu llave de Google Maps reemplazando el marcador `YOUR_GOOGLE_MAPS_API_KEY` en:
   - `SocialBusinessApp/SocialBusinessApp.Android/Properties/AndroidManifest.xml`
   - `SocialBusinessApp/SocialBusinessApp.iOS/AppDelegate.cs`

3. Elige el proyecto `SocialBusinessApp.Android` (o iOS) como inicial y pulsa **Ejecutar**.

Para firmar una versión de producción necesitas tu propio archivo `.keystore`, que no se incluye en el repositorio.

## Seguridad

La llave de Google Maps y los archivos de firma (`.keystore`) ya no se versionan. El historial de Git anterior los contiene, por lo que deben considerarse comprometidos: restringe la llave por paquete y huella en Google Cloud y evalúa rotar la firma de la app.

## Licencia

Sin licencia de código abierto. Todos los derechos reservados.
