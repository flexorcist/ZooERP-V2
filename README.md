Архитектура приложения:

ZooERP.Domain/ ----------------- Доменное ядро без зависимостей
	Common/ ---------------- Базовые типы (Entity, ValueObject, IDomainEvent, IAggregateRoot...)
	Animals/ --------------- Агрегат "Животные"
	Enclosures/ ------------ Агрегат "Клетки"
	Feeding/ --------------- Агрегат "Расписание кормлений"
	Events/ ---------------- Доменные события
	Repositories/ ---------- Репозитории

ZooERP.Application/ ------------ Use cases
	DTOs/ ------------------ Входные/выходные модели API
	Services/ -------------- Use‑case сервисы: интерфейсы + реализации
	Mappings/ -------------- AutoMapper + резолверы
	DI/ -------------------- DependencyInjection

ZooERP.Infrastructure/ --------- Техническая реализация (In‑memory, внешние сервисы)
	Persistence/ ----------- In‑memory репозитории
	Services/ -------------- Внешние сервисы
	DI/ -------------------- DependencyInjection

ZooERP.ERPzooV2/ --------------- Веб‑слой
	Controllers/ ----------- REST‑контроллеры
	Program.cs ------------- Настройка хоста, DI, Swagger, маппинг маршрутов



Реализованный функционал:

1. Добавить / удалить животное
AnimalManagementService (Application/Services) + AnimalsController (ERPzooV2/Controllers)
2. Регистрация новых видов
SpeciesService + SpeciesController (POST /api/species)
3. Добавить / удалить вольер
EnclosureManagementService + EnclosuresController
4. Поместить животное в вольер
EnclosureManagementService.AddAnimalToEnclosure + POST /api/enclosures/{id}/animals
5. Переместить животное между вольерами
AnimalTransferService + POST /api/animals/{id}/transfer в AnimalsController
6. Добавить новое кормление в расписание
FeedingOrganizationService.Schedule + POST /api/feeding
7. Просмотреть расписание кормления
GET /api/feeding и FeedingController.GetAll (ERPzooV2/Controllers)
8. Просмотреть статистику зоопарка (кол‑во животных, свободные слоты ...)
ZooStatisticsService.GetStatistics + StatisticsController

... и прочие полезные методы!



Применённые концепции DDD и Clean Architecture
1. Сущности (Entities)
Animal, Enclosure, FeedingSchedule - корни агрегатов (Domain/Animals/Animal.cs, Domain/Enclosures/Enclosure.cs, Domain/Feeding/FeedingSchedule.cs)
2. Value Objects
AnimalId, EnclosureId, FeedingScheduleId, Species, AnimalName, FoodConsumption, Size, FeedingTime, FoodType (Domain/Common и соответствующие подпапки)
3. Aggregate Roots
IAggregateRoot в классах Animal, Enclosure, FeedingSchedule
4. Доменные события
Интерфейс IDomainEvent + события AnimalMovedEvent, AnimalFedEvent, AnimalTreatedEvent, EnclosureCleanedEvent, FeedingTimeEvent (Domain/Events)
5. Репозитории 
IAnimalRepository, IEnclosureRepository, IFeedingScheduleRepository (Domain/Repositories)
6. Use‑case
IAnimalManagementService, IEnclosureManagementService, IAnimalTransferService, IFeedingOrganizationService, IZooStatisticsService, ISpeciesService (Application/Services)
7. DTO и маппинг
DTO в Application/DTOs; DomainToDtoProfile + KindnessResolver, CanContactResolver (Application/Mappings)
8. Изоляция бизнес‑логики
Вся логика (валидация входных данных, бросание событий ...) внутри Domain и Application. Внешние детали (хранение, HTTP, DI) вынесены в Infrastructure и Presentation.



По зависимостям:
- Domain не использует Application или Infrastructure
- Application использует только Domain
- Infrastructure использует только Domain и Application (для DI)
- Presentation использует Application и Infrastructure