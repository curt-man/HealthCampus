CREATE TABLE [Address] (
  [Id] Int,
  [Street] String,
  [City] String
);

CREATE TABLE [Address] (
  [Id] Int,
  [Street] String,
  [City] String
);

CREATE TABLE [Pharmacy] (
  [Id] Int,
  [Name] String,
  [Address] String,
  [PhoneNumber] String,
  [Medicines] List<Medicine>,
  CONSTRAINT [FK_Pharmacy.Address]
    FOREIGN KEY ([Address])
      REFERENCES [Address]([Id])
);

CREATE TABLE [Address] (
  [Id] Int,
  [Street] String,
  [City] String
);

CREATE TABLE [Manufacturer] (
  [Id] Int,
  [Name] String,
  [Number] String,
  [Address] Address,
  [AddressId] Int,
  [Medicines] List<Medicine>,
  [Description] String,
  CONSTRAINT [FK_Manufacturer.AddressId]
    FOREIGN KEY ([AddressId])
      REFERENCES [Address]([Id])
);

CREATE TABLE [Specialist] (
  [Id] GUID,
  [Description] String,
  [AverageRating] Float,
  [Reviews] List<Review>,
  [WorkRecords] List<WorkRecord>,
  [CurrentJob] WorkRecord,
  [CurrentJobId] Int,
  [SpecialistStatus] Byte
);

CREATE TABLE [Patient] (
  [Id] GUID,
  [Description] String,
  [PersonalHistory] List<Disease>,
  [FamilyHistory] List<Disease>
);

CREATE TABLE [FileContentType] (
  [Id] Byte,
  [MediaType] String,
  [SubType] String,
  [Extension] String,
  [Description] String
);

CREATE TABLE [AppFile] (
  [Id] GUID,
  [OriginalName] String,
  [FileContentType] FileContentType,
  [FileContentTypeId] Byte,
  [Size] Int,
  [Duration] Int,
  [Url] String,
  [ThumbnailUrl] String,
  [DownloadUrl] String,
  [UploadedDate] DateTime,
  [ModifiedDate] DateTime,
  [UploadedByUserId] GUID,
  [ModifiedByUserId] GUID,
  [IsPulbic] Bool,
  CONSTRAINT [FK_AppFile.UploadedByUserId]
    FOREIGN KEY ([UploadedByUserId])
      REFERENCES [User]([Id]),
  CONSTRAINT [FK_AppFile.FileContentTypeId]
    FOREIGN KEY ([FileContentTypeId])
      REFERENCES [FileContentType]([Id])
);

CREATE TABLE [User] (
  [Id] GUID,
  [FirstName] String,
  [LastName] String,
  [SecondName] String,
  [UserINN] Long,
  [Role] Byte,
  [BirthDate] Date,
  [Sex] Byte,
  [RegistrationDate] DateTime,
  [ModifiedDate] DateTime,
  [ProfilePicture] AppFile,
  [ProfilePictureId] GUID,
  [Addresses] List<Address>,
  [Languages] List<Language>,
  [Chats] List<Chats>,
  [UserStatus] Byte,
  CONSTRAINT [FK_User.Id]
    FOREIGN KEY ([Id])
      REFERENCES [Specialist]([Id]),
  CONSTRAINT [FK_User.Id]
    FOREIGN KEY ([Id])
      REFERENCES [Patient]([Id]),
  CONSTRAINT [FK_User.ProfilePictureId]
    FOREIGN KEY ([ProfilePictureId])
      REFERENCES [AppFile]([Id])
);

CREATE TABLE [Cart] (
  [Id] Int,
  [UserId] GUID,
  [NumberOfItems] Int,
  [CartItems] List<CartItem>,
  CONSTRAINT [FK_Cart.UserId]
    FOREIGN KEY ([UserId])
      REFERENCES [User]([Id])
);

CREATE TABLE [Medicine] (
  [Id] Int,
  [Id] GUID,
  [Name] String,
  [Dosage] Float,
  [UnitOfMesarument] Int,
  [IsPrescriptive] Bool,
  [Description] String,
  [Manufacturer] Manufacturer,
  [ManufacturerId] Int,
  [MedicineINN] String,
  [Composition] String,
  [StorageConditions] String,
  [SideEffects] String,
  [Discounts] List<Discount>,
  [Categories] List<Category>,
  [Images] List<AppFile>,
  [Documents] List<AppFile>,
  [Pharmacies] List<Pharmacy>,
  CONSTRAINT [FK_Medicine.ManufacturerId]
    FOREIGN KEY ([ManufacturerId])
      REFERENCES [Manufacturer]([Id])
);

CREATE TABLE [CartItem] (
  [Id] Int,
  [CartId] Int,
  [MedicineId] Int,
  [Quantity] Int,
  CONSTRAINT [FK_CartItem.CartId]
    FOREIGN KEY ([CartId])
      REFERENCES [Cart]([Id]),
  CONSTRAINT [FK_CartItem.MedicineId]
    FOREIGN KEY ([MedicineId])
      REFERENCES [Medicine]([Id])
);

CREATE TABLE [Category] (
  [Id] Int,
  [Name] String,
  [Medicines] List<Medicine>,
  [Discounts] List<Discount>
);

CREATE TABLE [PaymentStatus] (
  [Id] Int,
  [Status] String,
  [Description] String
);

CREATE TABLE [OrderStatus] (
  [Id] Int,
  [Status] String,
  [Description] String
);

CREATE TABLE [Carrier] (
  [Id] Int,
  [FirstName] String,
  [LastName] String,
  [PhoneNumber] String,
  [Location] Location,
  [LocationId] Int,
  [CarrierStatus] Byte
);

CREATE TABLE [DeliveryStatus] (
  [Id] Int,
  [Status] String,
  [Description] String
);

CREATE TABLE [Delivery] (
  [Id] Int,
  [RecieverName] String,
  [CarrierId] GUID,
  [TrackingNumber] String,
  [SentDate] DateTime,
  [RecievedDate] DateTime,
  [Address] Address,
  [AddressId] Int,
  [PhoneNumber] String,
  [DeliveryStatus] Int,
  CONSTRAINT [FK_Delivery.CarrierId]
    FOREIGN KEY ([CarrierId])
      REFERENCES [Carrier]([Id]),
  CONSTRAINT [FK_Delivery.AddressId]
    FOREIGN KEY ([AddressId])
      REFERENCES [Address]([Id]),
  CONSTRAINT [FK_Delivery.DeliveryStatus]
    FOREIGN KEY ([DeliveryStatus])
      REFERENCES [DeliveryStatus]([Id])
);

CREATE TABLE [Order] (
  [Id] Int,
  [UserId] GUID,
  [NumberOfItems] Int,
  [OrderDate] DateTime,
  [ModifiedDate] DateTime,
  [OrderTotal] Decimal,
  [OrderStatus] Int,
  [PaymentMethod] Int,
  [PaymentStatus] Int,
  [Delivery] Delivery,
  [DeliveryId] Int,
  [OrderItems] List<OrderItem>,
  CONSTRAINT [FK_Order.PaymentStatus]
    FOREIGN KEY ([PaymentStatus])
      REFERENCES [PaymentStatus]([Id]),
  CONSTRAINT [FK_Order.OrderStatus]
    FOREIGN KEY ([OrderStatus])
      REFERENCES [OrderStatus]([Id]),
  CONSTRAINT [FK_Order.UserId]
    FOREIGN KEY ([UserId])
      REFERENCES [User]([Id]),
  CONSTRAINT [FK_Order.DeliveryId]
    FOREIGN KEY ([DeliveryId])
      REFERENCES [Delivery]([Id])
);

CREATE TABLE [OrderItem] (
  [Id] Int,
  [OrderId] Int,
  [PharmacyId] Int,
  [Medicine] Medicine,
  [MedicineId] Int,
  [Quantity] Int,
  [Price] Decimal,
  [Discounts] List<Discount>,
  CONSTRAINT [FK_OrderItem.MedicineId]
    FOREIGN KEY ([MedicineId])
      REFERENCES [Medicine]([Id]),
  CONSTRAINT [FK_OrderItem.PharmacyId]
    FOREIGN KEY ([PharmacyId])
      REFERENCES [Pharmacy]([Id]),
  CONSTRAINT [FK_OrderItem.OrderId]
    FOREIGN KEY ([OrderId])
      REFERENCES [Order]([Id])
);

CREATE TABLE [Discount] (
  [Id] Int,
  [Name] String,
  [Description] String,
  [DiscountStatus] Byte,
  [PercentOff] Byte,
  [Medicines] List<Medicine>,
  [Categories] List<Categories>
);

CREATE TABLE [PrescriptionStatus] (
  [Id] Byte,
  [Name] String,
  [Description] String
);

CREATE TABLE [Prescription] (
  [Id] Int,
  [PatientId] GUID,
  [SpecialistId] GUID,
  [Medicines] List<Medicine>,
  [CreatedDate] DateTime,
  [ModifiedDate] DateTime,
  [UsedDate] DateTime,
  [PrescriptionStatus] Byte,
  CONSTRAINT [FK_Prescription.SpecialistId]
    FOREIGN KEY ([SpecialistId])
      REFERENCES [Specialist]([Id]),
  CONSTRAINT [FK_Prescription.PrescriptionStatus]
    FOREIGN KEY ([PrescriptionStatus])
      REFERENCES [PrescriptionStatus]([Id]),
  CONSTRAINT [FK_Prescription.PatientId]
    FOREIGN KEY ([PatientId])
      REFERENCES [Patient]([Id])
);

CREATE TABLE [ReviewStatus] (
  [Id] Byte,
  [Name] String,
  [Description] String
);

CREATE TABLE [InfrastructureAppFile] (
  [AppFileId] GUID,
  [MessageId] Int,
  CONSTRAINT [FK_InfrastructureAppFile.AppFileId]
    FOREIGN KEY ([AppFileId])
      REFERENCES [AppFile]([Id])
);

CREATE TABLE [Chat] (
  [Id] Int,
  [Users] List<User>,
  [Messages] List<Message>,
  [IsAnonymous] Bool,
  [ChatStatus] Byte
);

CREATE TABLE [ChatRole] (
  [Id] Byte,
  [Name] String,
  [Description] String
);

CREATE TABLE [ChatUser] (
  [ChatId] Int,
  [UserId] GUID,
  [JoinedDate] DateTime,
  [IsSpecialist] Bool,
  [ChatRole] Byte,
  CONSTRAINT [FK_ChatUser.ChatId]
    FOREIGN KEY ([ChatId])
      REFERENCES [Chat]([Id]),
  CONSTRAINT [FK_ChatUser.ChatRole]
    FOREIGN KEY ([ChatRole])
      REFERENCES [ChatRole]([Id]),
  CONSTRAINT [FK_ChatUser.UserId]
    FOREIGN KEY ([UserId])
      REFERENCES [User]([Id])
);

CREATE TABLE [Disease] (
  [Id] Int,
  [Name] Type,
  [Description] String,
  [PatientId] GUID,
  [DiseaseRecords] List<DiseaseRecord>,
  [StartedDate] DateTime,
  [ModifiedDate] DateTime,
  CONSTRAINT [FK_Disease.PatientId]
    FOREIGN KEY ([PatientId])
      REFERENCES [Patient]([Id])
);

CREATE TABLE [DiseaseRecord] (
  [Id] Int,
  [DiseaseId] Int,
  [Text] String,
  [CreatedDate] DateTime,
  [ModifiedDate] DateTime,
  CONSTRAINT [FK_DiseaseRecord.DiseaseId]
    FOREIGN KEY ([DiseaseId])
      REFERENCES [Disease]([Id])
);

CREATE TABLE [Message] (
  [Id] Int,
  [SentDate] DateTime,
  [AppFiles] List<AppFile>,
  [Text] String,
  [Sender] User,
  [SenderId] GUID,
  [RepliedMessage] Message,
  [RepliedMessageId] Int,
  [MessageStatus] Byte,
  [ChatId] Int,
  [IsForwarded] Bool,
  CONSTRAINT [FK_Message.SenderId]
    FOREIGN KEY ([SenderId])
      REFERENCES [User]([Id]),
  CONSTRAINT [FK_Message.ChatId]
    FOREIGN KEY ([ChatId])
      REFERENCES [Chat]([Id])
);

CREATE TABLE [MessageReciever] (
  [MessageId] Int,
  [RecieverId] GUID,
  [RecievedDate] DateTime,
  [ReadDate] DateTime,
  CONSTRAINT [FK_MessageReciever.RecieverId]
    FOREIGN KEY ([RecieverId])
      REFERENCES [User]([Id]),
  CONSTRAINT [FK_MessageReciever.MessageId]
    FOREIGN KEY ([MessageId])
      REFERENCES [Message]([Id])
);

CREATE TABLE [Address] (
  [Id] Int,
  [Street] String,
  [City] String
);

CREATE TABLE [Hospital] (
  [Id] Int,
  [Name] String,
  [Description] String,
  [Address] Address,
  [AddressId] Int,
  [Specialists] List<Specialist>,
  [WebSite] String,
  CONSTRAINT [FK_Hospital.AddressId]
    FOREIGN KEY ([AddressId])
      REFERENCES [Address]([Id])
);

CREATE TABLE [CategoryDiscount] (
  [CategoryId] Int,
  [DiscountId] Int,
  CONSTRAINT [FK_CategoryDiscount.DiscountId]
    FOREIGN KEY ([DiscountId])
      REFERENCES [Discount]([Id]),
  CONSTRAINT [FK_CategoryDiscount.CategoryId]
    FOREIGN KEY ([CategoryId])
      REFERENCES [Category]([Id])
);

CREATE TABLE [MedicineAppFile] (
  [AppFileId] GUID,
  [MedicineId] Int,
  CONSTRAINT [FK_MedicineAppFile.AppFileId]
    FOREIGN KEY ([AppFileId])
      REFERENCES [AppFile]([Id])
);

CREATE TABLE [Position] (
  [Id] Int,
  [Name] String,
  [Description] String
);

CREATE TABLE [Containers] (
  [ProfilePictures] <type>,
  [ChatImages] <type>,
  [ChatAudios] <type>,
  [ChatVideos] <type>,
  [ChatApplications] <type>,
  [ChatTexts] <type>,
  [MedicinePictures] <type>,
  [MedicineVideos] <type>,
  [MedicineApplications] <type>,
  [InfrastructureImages] <type>,
  [InfrastructureVideos] <type>,
  [InfrastructureApplications] <type>
);

CREATE TABLE [Address] (
  [Id] Int,
  [Street] String,
  [City] String
);

CREATE TABLE [UserAddress] (
  [UserId] GUID,
  [AddressId] Id,
  [IsMain] Bool,
  CONSTRAINT [FK_UserAddress.AddressId]
    FOREIGN KEY ([AddressId])
      REFERENCES [Address]([Id]),
  CONSTRAINT [FK_UserAddress.UserId]
    FOREIGN KEY ([UserId])
      REFERENCES [User]([Id])
);

CREATE TABLE [MessageAppFile] (
  [AppFileId] GUID,
  [MessageId] Int,
  CONSTRAINT [FK_MessageAppFile.AppFileId]
    FOREIGN KEY ([AppFileId])
      REFERENCES [AppFile]([Id])
);

CREATE TABLE [Review] (
  [Id] Int,
  [Rating] Float,
  [Text] String,
  [Images] List<AppFile>,
  [Patient] Patient,
  [PatientId] GUID,
  [Specialist] Specialist,
  [SpecialistId] GUID,
  [CreatedDate] DateTime,
  [ReviewStatus] Byte,
  CONSTRAINT [FK_Review.ReviewStatus]
    FOREIGN KEY ([ReviewStatus])
      REFERENCES [ReviewStatus]([Id]),
  CONSTRAINT [FK_Review.SpecialistId]
    FOREIGN KEY ([SpecialistId])
      REFERENCES [Specialist]([Id]),
  CONSTRAINT [FK_Review.PatientId]
    FOREIGN KEY ([PatientId])
      REFERENCES [Patient]([Id])
);

CREATE TABLE [MedicinePharmacy] (
  [MedicineId] Int,
  [PharmacyId] Int,
  [QuantityAvailable] Int,
  [QuantityRequired] Int,
  [IsDiscontinued] Bool,
  CONSTRAINT [FK_MedicinePharmacy.MedicineId]
    FOREIGN KEY ([MedicineId])
      REFERENCES [Medicine]([Id]),
  CONSTRAINT [FK_MedicinePharmacy.PharmacyId]
    FOREIGN KEY ([PharmacyId])
      REFERENCES [Pharmacy]([Id])
);

CREATE TABLE [MedicineCategory] (
  [MedicineId] Int,
  [CategoryId] Int,
  CONSTRAINT [FK_MedicineCategory.MedicineId]
    FOREIGN KEY ([MedicineId])
      REFERENCES [Medicine]([Id]),
  CONSTRAINT [FK_MedicineCategory.CategoryId]
    FOREIGN KEY ([CategoryId])
      REFERENCES [Category]([Id])
);

CREATE TABLE [MedicineDiscount] (
  [MedicineId] Int,
  [DiscountId] Int,
  CONSTRAINT [FK_MedicineDiscount.MedicineId]
    FOREIGN KEY ([MedicineId])
      REFERENCES [Medicine]([Id]),
  CONSTRAINT [FK_MedicineDiscount.DiscountId]
    FOREIGN KEY ([DiscountId])
      REFERENCES [Discount]([Id])
);

CREATE TABLE [WorkRecord] (
  [Id] Int,
  [Position] Position,
  [PositionId] Int,
  [Hospital] Hospital,
  [HospitalId] Int,
  [Specialist] Specialist,
  [SpecialistId] GUID,
  [StartedDate] DateTime,
  [EndedDate] DateTime,
  CONSTRAINT [FK_WorkRecord.PositionId]
    FOREIGN KEY ([PositionId])
      REFERENCES [Position]([Id]),
  CONSTRAINT [FK_WorkRecord.SpecialistId]
    FOREIGN KEY ([SpecialistId])
      REFERENCES [Specialist]([Id]),
  CONSTRAINT [FK_WorkRecord.HospitalId]
    FOREIGN KEY ([HospitalId])
      REFERENCES [Hospital]([Id])
);

