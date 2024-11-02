# API de Validación de Suscripciones

Este proyecto es una API construida en .NET Core 6 diseñada para validar suscripciones. El código está estructurado para mantener la escalabilidad y facilitar futuras implementaciones de validaciones adicionales.

## Estructura del Proyecto

La estructura de carpetas está organizada para seguir un patrón que facilita el crecimiento de la API sin necesidad de cambios significativos. A continuación, se describe el propósito de cada carpeta principal:

- **Controllers**: Contiene los controladores de la API. Cada controlador se encarga de gestionar las solicitudes entrantes y delegar la lógica de negocio al servicio correspondiente.
  
- **Validators**: Incluye los validadores específicos para las solicitudes a los controladores, asegurando que los datos recibidos cumplan con los requisitos antes de procesarse.
  
- **Services**: La lógica de negocio principal se encuentra en esta carpeta. Cada servicio interactúa con otras capas (como gateways) y contiene métodos para la validación y el procesamiento de suscripciones.
  
- **DTO (Data Transfer Objects)**: Aquí están los objetos de transferencia de datos, que facilitan el envío de información estructurada entre las distintas capas de la API.

- **Models**: Define los modelos de datos utilizados en la API. Estos representan las entidades y las estructuras que interactúan con los servicios y los datos de la aplicación.
  
- **Gateway**: La capa gateway gestiona la comunicación externa (por ejemplo, con proveedores externos). Aquí se manejan las solicitudes HTTP hacia servicios externos, utilizando un patrón de fábrica para garantizar extensibilidad.

- **Factories**: Contiene las fábricas responsables de instanciar validadores y gateways según el proveedor o el tipo de suscripción solicitado.

## Uso de la API

La API expone endpoints para la validación de suscripciones. Cada solicitud debe especificar una `platform` para determinar el proveedor correspondiente y pasar las validaciones necesarias antes de la ejecución de la lógica de negocio.

## Extensibilidad

Gracias a la estructura de **factories** y **validators**, la API permite agregar nuevos proveedores y métodos de validación sin modificar los controladores. Esto asegura que, en caso de cambios, solo deban ajustarse las implementaciones de gateways y validadores específicos.

## Ejecución y Desarrollo

Para ejecutar y depurar la API, simplemente clona el repositorio y utiliza el siguiente comando:

```bash
dotnet run
