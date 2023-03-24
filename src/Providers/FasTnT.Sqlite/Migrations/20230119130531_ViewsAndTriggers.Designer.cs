﻿// <auto-generated />
using System;
using FasTnT.Application.Storage;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FasTnT.Sqlite.Migrations
{
    [DbContext(typeof(EpcisContext))]
    [Migration("20230119130531_ViewsAndTriggers")]
    partial class ViewsAndTriggers
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("FasTnT.Domain.Model.CustomQueries.StoredQuery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("StoredQuery", "Queries");
                });

            modelBuilder.Entity("FasTnT.Domain.Model.Events.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<short>("Action")
                        .HasColumnType("INTEGER");

                    b.Property<string>("BusinessLocation")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("BusinessStep")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CaptureTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("CertificationInfo")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("CorrectiveDeclarationTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("CorrectiveReason")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("Disposition")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("EventId")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("EventTime")
                        .HasColumnType("TEXT");

                    b.Property<short>("EventTimeZoneOffset")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ReadPoint")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<int?>("RequestId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TransformationId")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<short>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RequestId");

                    b.ToTable("Event", "Epcis");
                });

            modelBuilder.Entity("FasTnT.Domain.Model.Masterdata.MasterData", b =>
                {
                    b.Property<int>("RequestId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("Id")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("RequestId", "Type", "Id");

                    b.ToTable("MasterData", "Cbv");

                    b.ToView("CurrentMasterdata", "Cbv");

                    b.HasDiscriminator<string>("Type").IsComplete(false).HasValue("MasterData");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("FasTnT.Domain.Model.Masterdata.MasterDataHierarchy", b =>
                {
                    b.Property<string>("Id")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Root")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.ToTable((string)null);

                    b.ToView("MasterDataHierarchy", "Cbv");

                    b.HasDiscriminator<string>("Type").IsComplete(false).HasValue("MasterDataHierarchy");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("FasTnT.Domain.Model.Request", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CaptureId")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CaptureTime")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DocumentTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("SchemaVersion")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .HasMaxLength(50)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Request", "Epcis", t =>
                        {
                            t.HasTrigger("SubscriptionPendingRequests");
                        });
                });

            modelBuilder.Entity("FasTnT.Domain.Model.Subscriptions.PendingRequest", b =>
                {
                    b.Property<int>("SubscriptionId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RequestId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SubscriptionId", "RequestId");

                    b.ToTable("PendingRequest", "Subscriptions");
                });

            modelBuilder.Entity("FasTnT.Domain.Model.Subscriptions.Subscription", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("TEXT");

                    b.Property<string>("FormatterName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("InitialRecordTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("QueryName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("ReportIfEmpty")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SignatureToken")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("Trigger")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Subscription", "Subscriptions", t =>
                        {
                            t.HasTrigger("SubscriptionInitialRequests");
                        });
                });

            modelBuilder.Entity("FasTnT.Domain.Model.Subscriptions.SubscriptionExecutionRecord", b =>
                {
                    b.Property<int>("SubscriptionId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("ExecutionTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("Reason")
                        .HasColumnType("TEXT");

                    b.Property<bool>("ResultsSent")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Successful")
                        .HasColumnType("INTEGER");

                    b.HasKey("SubscriptionId", "ExecutionTime");

                    b.ToTable("SubscriptionExecutionRecord", "Subscriptions");
                });

            modelBuilder.Entity("FasTnT.Domain.Model.Masterdata.BizLocation", b =>
                {
                    b.HasBaseType("FasTnT.Domain.Model.Masterdata.MasterData");

                    b.HasDiscriminator().HasValue("urn:epcglobal:epcis:vtype:BusinessLocation");
                });

            modelBuilder.Entity("FasTnT.Domain.Model.Masterdata.ReadPoint", b =>
                {
                    b.HasBaseType("FasTnT.Domain.Model.Masterdata.MasterData");

                    b.HasDiscriminator().HasValue("urn:epcglobal:epcis:vtype:ReadPoint");
                });

            modelBuilder.Entity("FasTnT.Domain.Model.Masterdata.BizLocationHierarchy", b =>
                {
                    b.HasBaseType("FasTnT.Domain.Model.Masterdata.MasterDataHierarchy");

                    b.HasDiscriminator().HasValue("urn:epcglobal:epcis:vtype:BusinessLocation");
                });

            modelBuilder.Entity("FasTnT.Domain.Model.Masterdata.ReadPointHierarchy", b =>
                {
                    b.HasBaseType("FasTnT.Domain.Model.Masterdata.MasterDataHierarchy");

                    b.HasDiscriminator().HasValue("urn:epcglobal:epcis:vtype:ReadPoint");
                });

            modelBuilder.Entity("FasTnT.Domain.Model.CustomQueries.StoredQuery", b =>
                {
                    b.OwnsMany("FasTnT.Domain.Model.CustomQueries.StoredQueryParameter", "Parameters", b1 =>
                        {
                            b1.Property<int>("QueryId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Name")
                                .HasMaxLength(256)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Values")
                                .HasColumnType("TEXT");

                            b1.HasKey("QueryId", "Name");

                            b1.ToTable("StoredQueryParameter", "Queries");

                            b1.WithOwner("Query")
                                .HasForeignKey("QueryId");

                            b1.Navigation("Query");
                        });

                    b.Navigation("Parameters");
                });

            modelBuilder.Entity("FasTnT.Domain.Model.Events.Event", b =>
                {
                    b.HasOne("FasTnT.Domain.Model.Request", "Request")
                        .WithMany("Events")
                        .HasForeignKey("RequestId");

                    b.OwnsMany("FasTnT.Domain.Model.Events.BusinessTransaction", "Transactions", b1 =>
                        {
                            b1.Property<int>("EventId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Type")
                                .HasMaxLength(256)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Id")
                                .HasMaxLength(256)
                                .HasColumnType("TEXT");

                            b1.HasKey("EventId", "Type", "Id");

                            b1.ToTable("BusinessTransaction", "Epcis");

                            b1.WithOwner("Event")
                                .HasForeignKey("EventId");

                            b1.Navigation("Event");
                        });

                    b.OwnsMany("FasTnT.Domain.Model.Events.CorrectiveEventId", "CorrectiveEventIds", b1 =>
                        {
                            b1.Property<int>("EventId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("CorrectiveId")
                                .HasMaxLength(256)
                                .HasColumnType("TEXT");

                            b1.HasKey("EventId", "CorrectiveId");

                            b1.ToTable("CorrectiveEventId", "Epcis");

                            b1.WithOwner("Event")
                                .HasForeignKey("EventId");

                            b1.Navigation("Event");
                        });

                    b.OwnsMany("FasTnT.Domain.Model.Events.Destination", "Destinations", b1 =>
                        {
                            b1.Property<int>("EventId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Type")
                                .HasMaxLength(256)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Id")
                                .HasMaxLength(256)
                                .HasColumnType("TEXT");

                            b1.HasKey("EventId", "Type", "Id");

                            b1.ToTable("Destination", "Epcis");

                            b1.WithOwner("Event")
                                .HasForeignKey("EventId");

                            b1.Navigation("Event");
                        });

                    b.OwnsMany("FasTnT.Domain.Model.Events.Epc", "Epcs", b1 =>
                        {
                            b1.Property<int>("EventId")
                                .HasColumnType("INTEGER");

                            b1.Property<short>("Type")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Id")
                                .HasMaxLength(256)
                                .HasColumnType("TEXT");

                            b1.Property<float?>("Quantity")
                                .HasColumnType("REAL");

                            b1.Property<string>("UnitOfMeasure")
                                .HasMaxLength(10)
                                .HasColumnType("TEXT");

                            b1.HasKey("EventId", "Type", "Id");

                            b1.ToTable("Epc", "Epcis");

                            b1.WithOwner("Event")
                                .HasForeignKey("EventId");

                            b1.Navigation("Event");
                        });

                    b.OwnsMany("FasTnT.Domain.Model.Events.Field", "Fields", b1 =>
                        {
                            b1.Property<int>("EventId")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("Index")
                                .HasColumnType("INTEGER");

                            b1.Property<DateTime?>("DateValue")
                                .HasColumnType("TEXT");

                            b1.Property<int?>("EntityIndex")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(256)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Namespace")
                                .HasMaxLength(256)
                                .HasColumnType("TEXT");

                            b1.Property<double?>("NumericValue")
                                .HasColumnType("REAL");

                            b1.Property<int?>("ParentIndex")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("TextValue")
                                .HasMaxLength(256)
                                .HasColumnType("TEXT");

                            b1.Property<short>("Type")
                                .HasColumnType("INTEGER");

                            b1.HasKey("EventId", "Index");

                            b1.ToTable("Field", "Epcis");

                            b1.WithOwner("Event")
                                .HasForeignKey("EventId");

                            b1.Navigation("Event");
                        });

                    b.OwnsMany("FasTnT.Domain.Model.Events.PersistentDisposition", "PersistentDispositions", b1 =>
                        {
                            b1.Property<int>("EventId")
                                .HasColumnType("INTEGER");

                            b1.Property<short>("Type")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Id")
                                .HasMaxLength(256)
                                .HasColumnType("TEXT");

                            b1.HasKey("EventId", "Type", "Id");

                            b1.ToTable("PersistentDisposition", "Epcis");

                            b1.WithOwner("Event")
                                .HasForeignKey("EventId");

                            b1.Navigation("Event");
                        });

                    b.OwnsMany("FasTnT.Domain.Model.Events.SensorElement", "SensorElements", b1 =>
                        {
                            b1.Property<int>("EventId")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("Index")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("BizRules")
                                .HasMaxLength(256)
                                .HasColumnType("TEXT");

                            b1.Property<string>("DataProcessingMethod")
                                .HasMaxLength(256)
                                .HasColumnType("TEXT");

                            b1.Property<string>("DeviceId")
                                .HasMaxLength(256)
                                .HasColumnType("TEXT");

                            b1.Property<string>("DeviceMetadata")
                                .HasMaxLength(256)
                                .HasColumnType("TEXT");

                            b1.Property<DateTime?>("EndTime")
                                .HasColumnType("TEXT");

                            b1.Property<string>("RawData")
                                .HasMaxLength(2048)
                                .HasColumnType("TEXT");

                            b1.Property<DateTime?>("StartTime")
                                .HasColumnType("TEXT");

                            b1.Property<DateTime?>("Time")
                                .HasColumnType("TEXT");

                            b1.HasKey("EventId", "Index");

                            b1.ToTable("SensorElement", "Epcis");

                            b1.WithOwner("Event")
                                .HasForeignKey("EventId");

                            b1.OwnsMany("FasTnT.Domain.Model.Events.SensorReport", "Reports", b2 =>
                                {
                                    b2.Property<int>("EventId")
                                        .HasColumnType("INTEGER");

                                    b2.Property<int>("SensorIndex")
                                        .HasColumnType("INTEGER");

                                    b2.Property<int>("Index")
                                        .HasColumnType("INTEGER");

                                    b2.Property<bool>("BooleanValue")
                                        .HasColumnType("INTEGER");

                                    b2.Property<string>("ChemicalSubstance")
                                        .HasMaxLength(256)
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("Component")
                                        .HasMaxLength(256)
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("DataProcessingMethod")
                                        .HasMaxLength(256)
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("DeviceId")
                                        .HasMaxLength(256)
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("DeviceMetadata")
                                        .HasMaxLength(256)
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("HexBinaryValue")
                                        .HasMaxLength(256)
                                        .HasColumnType("TEXT");

                                    b2.Property<float?>("MaxValue")
                                        .HasColumnType("REAL");

                                    b2.Property<float?>("MeanValue")
                                        .HasColumnType("REAL");

                                    b2.Property<string>("Microorganism")
                                        .HasMaxLength(256)
                                        .HasColumnType("TEXT");

                                    b2.Property<float?>("MinValue")
                                        .HasColumnType("REAL");

                                    b2.Property<float?>("PercRank")
                                        .HasColumnType("REAL");

                                    b2.Property<float?>("PercValue")
                                        .HasColumnType("REAL");

                                    b2.Property<string>("RawData")
                                        .HasMaxLength(2048)
                                        .HasColumnType("TEXT");

                                    b2.Property<float?>("SDev")
                                        .HasColumnType("REAL");

                                    b2.Property<string>("StringValue")
                                        .HasMaxLength(2048)
                                        .HasColumnType("TEXT");

                                    b2.Property<DateTime?>("Time")
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("Type")
                                        .HasMaxLength(256)
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("UnitOfMeasure")
                                        .HasMaxLength(256)
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("UriValue")
                                        .HasMaxLength(2048)
                                        .HasColumnType("TEXT");

                                    b2.Property<float?>("Value")
                                        .HasColumnType("REAL");

                                    b2.HasKey("EventId", "SensorIndex", "Index");

                                    b2.ToTable("SensorReport", "Epcis");

                                    b2.WithOwner("SensorElement")
                                        .HasForeignKey("EventId", "SensorIndex");

                                    b2.Navigation("SensorElement");
                                });

                            b1.Navigation("Event");

                            b1.Navigation("Reports");
                        });

                    b.OwnsMany("FasTnT.Domain.Model.Events.Source", "Sources", b1 =>
                        {
                            b1.Property<int>("EventId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Type")
                                .HasMaxLength(256)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Id")
                                .HasMaxLength(256)
                                .HasColumnType("TEXT");

                            b1.HasKey("EventId", "Type", "Id");

                            b1.ToTable("Source", "Epcis");

                            b1.WithOwner("Event")
                                .HasForeignKey("EventId");

                            b1.Navigation("Event");
                        });

                    b.Navigation("CorrectiveEventIds");

                    b.Navigation("Destinations");

                    b.Navigation("Epcs");

                    b.Navigation("Fields");

                    b.Navigation("PersistentDispositions");

                    b.Navigation("Request");

                    b.Navigation("SensorElements");

                    b.Navigation("Sources");

                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("FasTnT.Domain.Model.Masterdata.MasterData", b =>
                {
                    b.HasOne("FasTnT.Domain.Model.Request", "Request")
                        .WithMany("Masterdata")
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsMany("FasTnT.Domain.Model.Masterdata.MasterDataChildren", "Children", b1 =>
                        {
                            b1.Property<int>("MasterDataRequestId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("MasterDataType")
                                .HasColumnType("TEXT");

                            b1.Property<string>("MasterDataId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("ChildrenId")
                                .HasMaxLength(256)
                                .HasColumnType("TEXT");

                            b1.HasKey("MasterDataRequestId", "MasterDataType", "MasterDataId", "ChildrenId");

                            b1.ToTable("MasterDataChildren", "Cbv");

                            b1.WithOwner("MasterData")
                                .HasForeignKey("MasterDataRequestId", "MasterDataType", "MasterDataId");

                            b1.Navigation("MasterData");
                        });

                    b.OwnsMany("FasTnT.Domain.Model.Masterdata.MasterDataAttribute", "Attributes", b1 =>
                        {
                            b1.Property<int>("RequestId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("MasterdataType")
                                .HasMaxLength(256)
                                .HasColumnType("TEXT");

                            b1.Property<string>("MasterdataId")
                                .HasMaxLength(256)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Id")
                                .HasMaxLength(256)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Value")
                                .IsRequired()
                                .HasMaxLength(256)
                                .HasColumnType("TEXT");

                            b1.HasKey("RequestId", "MasterdataType", "MasterdataId", "Id");

                            b1.ToTable("MasterDataAttribute", "Cbv");

                            b1.WithOwner("MasterData")
                                .HasForeignKey("RequestId", "MasterdataType", "MasterdataId");

                            b1.OwnsMany("FasTnT.Domain.Model.Masterdata.MasterDataField", "Fields", b2 =>
                                {
                                    b2.Property<int>("RequestId")
                                        .HasColumnType("INTEGER");

                                    b2.Property<string>("MasterdataType")
                                        .HasMaxLength(256)
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("MasterdataId")
                                        .HasMaxLength(256)
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("AttributeId")
                                        .HasMaxLength(256)
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("Namespace")
                                        .HasMaxLength(256)
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("Name")
                                        .HasMaxLength(256)
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("ParentName")
                                        .HasMaxLength(256)
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("ParentNamespace")
                                        .HasMaxLength(256)
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("Value")
                                        .HasMaxLength(256)
                                        .HasColumnType("TEXT");

                                    b2.HasKey("RequestId", "MasterdataType", "MasterdataId", "AttributeId", "Namespace", "Name");

                                    b2.ToTable("MasterDataField", "Cbv");

                                    b2.WithOwner("Attribute")
                                        .HasForeignKey("RequestId", "MasterdataType", "MasterdataId", "AttributeId");

                                    b2.Navigation("Attribute");
                                });

                            b1.Navigation("Fields");

                            b1.Navigation("MasterData");
                        });

                    b.Navigation("Attributes");

                    b.Navigation("Children");

                    b.Navigation("Request");
                });

            modelBuilder.Entity("FasTnT.Domain.Model.Request", b =>
                {
                    b.OwnsOne("FasTnT.Domain.Model.StandardBusinessHeader", "StandardBusinessHeader", b1 =>
                        {
                            b1.Property<int>("RequestId")
                                .HasColumnType("INTEGER");

                            b1.Property<DateTime?>("CreationDateTime")
                                .HasColumnType("TEXT");

                            b1.Property<string>("InstanceIdentifier")
                                .IsRequired()
                                .HasMaxLength(256)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Standard")
                                .IsRequired()
                                .HasMaxLength(256)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Type")
                                .IsRequired()
                                .HasMaxLength(256)
                                .HasColumnType("TEXT");

                            b1.Property<string>("TypeVersion")
                                .IsRequired()
                                .HasMaxLength(256)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Version")
                                .IsRequired()
                                .HasMaxLength(256)
                                .HasColumnType("TEXT");

                            b1.HasKey("RequestId");

                            b1.ToTable("StandardBusinessHeader", "Sbdh");

                            b1.WithOwner("Request")
                                .HasForeignKey("RequestId");

                            b1.OwnsMany("FasTnT.Domain.Model.Events.ContactInformation", "ContactInformations", b2 =>
                                {
                                    b2.Property<int>("RequestId")
                                        .HasColumnType("INTEGER");

                                    b2.Property<short>("Type")
                                        .HasMaxLength(256)
                                        .HasColumnType("INTEGER");

                                    b2.Property<string>("Identifier")
                                        .HasMaxLength(256)
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("Contact")
                                        .HasMaxLength(256)
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("ContactTypeIdentifier")
                                        .HasMaxLength(256)
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("EmailAddress")
                                        .HasMaxLength(256)
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("FaxNumber")
                                        .HasMaxLength(256)
                                        .HasColumnType("TEXT");

                                    b2.Property<string>("TelephoneNumber")
                                        .HasMaxLength(256)
                                        .HasColumnType("TEXT");

                                    b2.HasKey("RequestId", "Type", "Identifier");

                                    b2.ToTable("ContactInformation", "Sbdh");

                                    b2.WithOwner("Header")
                                        .HasForeignKey("RequestId");

                                    b2.Navigation("Header");
                                });

                            b1.Navigation("ContactInformations");

                            b1.Navigation("Request");
                        });

                    b.OwnsOne("FasTnT.Domain.Model.Subscriptions.SubscriptionCallback", "SubscriptionCallback", b1 =>
                        {
                            b1.Property<int>("RequestId")
                                .HasColumnType("INTEGER");

                            b1.Property<short>("CallbackType")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Reason")
                                .HasMaxLength(256)
                                .HasColumnType("TEXT");

                            b1.Property<string>("SubscriptionId")
                                .IsRequired()
                                .HasMaxLength(256)
                                .HasColumnType("TEXT");

                            b1.HasKey("RequestId");

                            b1.ToTable("SubscriptionCallback", "Epcis");

                            b1.WithOwner("Request")
                                .HasForeignKey("RequestId");

                            b1.Navigation("Request");
                        });

                    b.Navigation("StandardBusinessHeader");

                    b.Navigation("SubscriptionCallback");
                });

            modelBuilder.Entity("FasTnT.Domain.Model.Subscriptions.Subscription", b =>
                {
                    b.OwnsMany("FasTnT.Domain.Model.Queries.QueryParameter", "Parameters", b1 =>
                        {
                            b1.Property<int>("SubscriptionId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("Name")
                                .HasMaxLength(256)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Values")
                                .HasColumnType("TEXT");

                            b1.HasKey("SubscriptionId", "Name");

                            b1.ToTable("SubscriptionParameter", "Subscriptions");

                            b1.WithOwner()
                                .HasForeignKey("SubscriptionId");
                        });

                    b.OwnsOne("FasTnT.Domain.Model.Subscriptions.SubscriptionSchedule", "Schedule", b1 =>
                        {
                            b1.Property<int>("SubscriptionId")
                                .HasColumnType("INTEGER");

                            b1.Property<string>("DayOfMonth")
                                .HasMaxLength(256)
                                .HasColumnType("TEXT");

                            b1.Property<string>("DayOfWeek")
                                .HasMaxLength(256)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Hour")
                                .HasMaxLength(256)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Minute")
                                .HasMaxLength(256)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Month")
                                .HasMaxLength(256)
                                .HasColumnType("TEXT");

                            b1.Property<string>("Second")
                                .HasMaxLength(256)
                                .HasColumnType("TEXT");

                            b1.HasKey("SubscriptionId");

                            b1.ToTable("SubscriptionSchedule", "Subscriptions");

                            b1.WithOwner()
                                .HasForeignKey("SubscriptionId");
                        });

                    b.Navigation("Parameters");

                    b.Navigation("Schedule");
                });

            modelBuilder.Entity("FasTnT.Domain.Model.Request", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("Masterdata");
                });
#pragma warning restore 612, 618
        }
    }
}
