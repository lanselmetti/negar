﻿namespace Scsi
{
    /// <summary>The MSB is the ASC, the LSB is the ASCQ</summary>
    public enum AdditionalSenseInformation : short
    {
        NoAdditionalSenseInformation = 0x0000,
        FilemarkDetected = 0x0001,
        EndOfPartitionOrMediumDetected = 0x0002,
        SetmarkDetected = 0x0003,
        BeginningOfPartitionOrMediumDetected = 0x0004,
        EndOfDataDetected = 0x0005,
        IOProcessTerminated = 0x0006,
        ProgrammableEarlyWarningDetected = 0x0007,
        AudioPlayOperationInProgress = 0x0011,
        AudioPlayOperationPaused = 0x0012,
        AudioPlayOperationSuccessfullyCompleted = 0x0013,
        AudioPlayOperationStoppedDueToError = 0x0014,
        NoCurrentAudioStatusToReturn = 0x0015,
        OperationInProgress = 0x0016,
        CleaningRequested = 0x0017,
        EraseOperationInProgress = 0x0018,
        LocateOperationInProgress = 0x0019,
        RewindOperationInProgress = 0x001A,
        SetCapacityOperationInProgress = 0x001B,
        VerifyOperationInProgress = 0x001C,
        AtaPassThroughInformationAvailable = 0x001D,
        ConflictingSaCreationRequest = 0x001E,
        NoIndex_SectorSignal = 0x0100,
        NoSeekComplete = 0x0200,
        PeripheralDeviceWriteFault = 0x0300,
        NoWriteCurrent = 0x0301,
        ExcessiveWriteErrors = 0x0302,
        LogicalUnitNotReady_CauseNotReportable = 0x0400,
        LogicalUnitIsInProcessOfBecomingReady = 0x0401,
        LogicalUnitNotReady_InitializingCommandRequired = 0x0402,
        LogicalUnitNotReady_ManualInterventionRequired = 0x0403,
        LogicalUnitNotReady_FormatInProgress = 0x0404,
        LogicalUnitNotReady_RebuildInProgress = 0x0405,
        LogicalUnitNotReady_RecalculationInProgress = 0x0406,
        LogicalUnitNotReady_OperationInProgress = 0x0407,
        LogicalUnitNotReady_LongWriteInProgress = 0x0408,
        LogicalUnitNotReady_SelfTestInProgress = 0x0409,
        LogicalUnitNotAccessible_AsymmetricAccessStateTransition = 0x040A,
        LogicalUnitNotAccessible_TargetPortInStandbyState = 0x040B,
        LogicalUnitNotAccessible_TargetPortInUnavailableState = 0x040C,
        LogicalUnitNotReady_StructureCheckRequired = 0x040D,
        LogicalUnitNotReady_AuxiliaryMemoryNotAccessible = 0x0410,
        LogicalUnitNotReady_NotifyRequired = 0x0411,
        LogicalUnitNotReady_Offline = 0x0412,
        LogicalUnitNotReady_SaCreationInProgress = 0x0413,
        LogicalUnitNotReady_SpaceAllocationInProgress = 0x0414,
        LogicalUnitNotReady_RoboticsDisabled = 0x0415,
        LogicalUnitNotReady_ConfigurationRequired = 0x0416,
        LogicalUnitNotReady_CalibrationRequired = 0x0417,
        LogicalUnitNotReady_ADoorIsOpen = 0x0418,
        LogicalUnitNotReady_OperatingInSequentialMode = 0x0419,
        LogicalUnitDoesNotRespondToSelection = 0x0500,
        NoReferencePositionFound = 0x0600,
        MultiplePeripheralDevicesSelected = 0x0700,
        LogicalUnitCommunicationFailure = 0x0800,
        LogicalUnitCommunicationTimeOut = 0x0801,
        LogicalUnitCommunicationParityError = 0x0802,
        LogicalUnitCommunicationCrcError_UltraDma32 = 0x0803,
        UnreachableCopyTarget = 0x0804,
        TrackFollowingError = 0x0900,
        TrackingServoFailure = 0x0901,
        FocusServoFailure = 0x0902,
        SpindleServoFailure = 0x0903,
        HeadSelectFault = 0x0904,
        ErrorLogOverflow = 0x0A00,
        Warning = 0x0B00,
        WarningSpecifiedTemperatureExceeded = 0x0B01,
        WarningEnclosureDegraded = 0x0B02,
        WarningBackgroundSelfTestFailed = 0x0B03,
        WarningBackgroundPreScanDetectedMediumError = 0x0B04,
        WarningBackgroundMediumScanDetectedMediumError = 0x0B05,
        WarningNonVolatileCacheNowVolatile = 0x0B06,
        WarningDegradedPowerToNonVolatileCache = 0x0B07,
        WarningPowerLossExpected = 0x0B08,
        WriteError = 0x0C00,
        WriteErrorRecoveredWithAutoReallocation = 0x0C01,
        WriteErrorAutoReallocationFailed = 0x0C02,
        WriteErrorRecommendReassignment = 0x0C03,
        CompressionCheckMiscompareError = 0x0C04,
        DataExpansionOccurredDuringCompression = 0x0C05,
        BlockNotCompressible = 0x0C06,
        WriteErrorRecoveryNeeded = 0x0C07,
        WriteErrorRecoveryFailed = 0x0C08,
        WriteErrorLossOfStreaming = 0x0C09,
        WriteErrorPaddingBlocksAdded = 0x0C0A,
        AuxiliaryMemoryWriteError = 0x0C0B,
        WriteErrorUnexpectedUnsolicitedData = 0x0C0C,
        WriteErrorNotEnoughUnsolicitedData = 0x0C0D,
        DefectsInErrorWindow = 0x0C0F,
        ErrorDetectedByThirdPartyTemporaryInitiator = 0x0D00,
        ThirdPartyDeviceFailure = 0x0D01,
        CopyTargetDeviceNotReachable = 0x0D02,
        IncorrectCopyTargetDeviceType = 0x0D03,
        CopyTargetDeviceDataUnderrun = 0x0D04,
        CopyTargetDeviceDataOverrun = 0x0D05,
        InvalidInformationUnit = 0x0E00,
        InformationUnitTooShort = 0x0E01,
        InformationUnitTooLong = 0x0E02,
        InvalidFieldInCommandInformationUnit = 0x0E03,
        IdCrcOrEccError = 0x1000,
        LogicalBlockGuardCheckFailed = 0x1001,
        LogicalBlockApplicationTagCheckFailed = 0x1002,
        LogicalBlockReferenceTagCheckFailed = 0x1003,
        UnrecoveredReadError = 0x1100,
        ReadRetriesExhausted = 0x1101,
        ErrorTooLongToCorrect = 0x1102,
        MultipleReadErrors = 0x1103,
        UnrecoveredReadErrorAutoReallocateFailed = 0x1104,
        LEcUncorrectableError = 0x1105,
        CircUnrecoveredError = 0x1106,
        DataReSynchronizationError = 0x1107,
        IncompleteBlockRead = 0x1108,
        NoGapFound = 0x1109,
        MiscorrectedError = 0x110A,
        UnrecoveredReadErrorRecommendReassignment = 0x110B,
        UnrecoveredReadErrorRecommendRewriteTheData = 0x110C,
        DeCompressionCrcError = 0x110D,
        CannotDecompressUsingDeclaredAlgorithm = 0x110E,
        ErrorReadingUpcOrEanNumber = 0x110F,
        ErrorReadingIsrcNumber = 0x1110,
        ReadErrorLossOfStreaming = 0x1111,
        AuxiliaryMemoryReadError = 0x1112,
        ReadErrorFailedRetransmissionRequest = 0x1113,
        ReadErrorLbaMarkedBadByApplicationClient = 0x1114,
        AddressMarkNotFoundForIdField = 0x1200,
        AddressMarkNotFoundForDataField = 0x1300,
        RecordedEntityNotFound = 0x1400,
        RecordNotFound = 0x1401,
        FilemarkOrSetmarkNotFound = 0x1402,
        EndOfDataNotFound = 0x1403,
        BlockSequenceError = 0x1404,
        RecordNotFoundRecommendReassignment = 0x1405,
        RecordNotFoundDataAutoReallocated = 0x1406,
        LocateOperationFailure = 0x1407,
        RandomPositioningError = 0x1500,
        MechanicalPositioningError = 0x1501,
        PositioningErrorDetectedByReadOfMedium = 0x1502,
        DataSynchronizationMarkError = 0x1600,
        DataSyncErrorDataRewritten = 0x1601,
        DataSyncErrorRecommendRewrite = 0x1602,
        DataSyncErrorDataAutoReallocated = 0x1603,
        DataSyncErrorRecommendReassignment = 0x1604,
        RecoveredDataWithNoErrorCorrectionApplied = 0x1700,
        RecoveredDataWithRetries = 0x1701,
        RecoveredDataWithPositiveHeadOffset = 0x1702,
        RecoveredDataWithNegativeHeadOffset = 0x1703,
        RecoveredDataWithRetriesOrCircApplied = 0x1704,
        RecoveredDataUsingPreviousSectorId = 0x1705,
        RecoveredDataWithoutEccDataAutoReallocated = 0x1706,
        RecoveredDataWithoutEccRecommendReassignment = 0x1707,
        RecoveredDataWithoutEccRecommendRewrite = 0x1708,
        RecoveredDataWithoutEccDataRewritten = 0x1709,
        RecoveredDataWithErrorCorrectionApplied = 0x1800,
        RecoveredDataWithErrorCorrectionAndRetriesApplied = 0x1801,
        RecoveredDataDataAutoReallocated = 0x1802,
        RecoveredDataWithCirc = 0x1803,
        RecoveredDataWithLEc = 0x1804,
        RecoveredDataRecommendReassignment = 0x1805,
        RecoveredDataRecommendRewrite = 0x1806,
        RecoveredDataWithEccDataRewritten = 0x1807,
        RecoveredDataWithLinking = 0x1808,
        DefectListError = 0x1900,
        DefectListNotAvailable = 0x1901,
        DefectListErrorInPrimaryList = 0x1902,
        DefectListErrorInGrownList = 0x1903,
        ParameterListLengthError = 0x1A00,
        SynchronousDataTransferError = 0x1B00,
        DefectListNotFound = 0x1C00,
        PrimaryDefectListNotFound = 0x1C01,
        GrownDefectListNotFound = 0x1C02,
        MiscompareDuringVerifyOperation = 0x1D00,
        MiscompareVerifyOfUnmappedLba = 0x1D01,
        RecoveredIdWithEccCorrection = 0x1E00,
        PartialDefectListTransfer = 0x1F00,
        InvalidCommandOperationCode = 0x2000,
        AccessDeniedInitiatorPendingEnrolled = 0x2001,
        AccessDeniedNoAccessRights = 0x2002,
        AccessDeniedInvalidMgmtIdKey = 0x2003,
        IllegalCommandWhileInWriteCapableState = 0x2004,
        //Obsolete = 0x2005,
        IllegalCommandWhileInExplicitAddressMode = 0x2006,
        IllegalCommandWhileInImplicitAddressMode = 0x2007,
        AccessDeniedEnrollmentConflict = 0x2008,
        AccessDeniedInvalidLuIdentifier = 0x2009,
        AccessDeniedInvalidProxyToken = 0x200A,
        AccessDeniedAclLunConflict = 0x200B,
        LogicalBlockAddressOutOfRange = 0x2100,
        InvalidElementAddress = 0x2101,
        InvalidAddressForWrite = 0x2102,
        InvalidWriteCrossingLayerJump = 0x2103,
        IllegalFunction_Use2000Or2400Or2600 = 0x2200,
        InvalidFieldInCdb = 0x2400,
        CdbDecryptionError = 0x2401,
        //Obsolete = 0x2402,
        //Obsolete = 0x2403,
        SecurityAuditValueFrozen = 0x2404,
        SecurityWorkingKeyFrozen = 0x2405,
        NonceNotUnique = 0x2406,
        NonceTimestampOutOfRange = 0x2407,
        InvalidXcdb = 0x2408,
        LogicalUnitNotSupported = 0x2500,
        InvalidFieldInParameterList = 0x2600,
        ParameterNotSupported = 0x2601,
        ParameterValueInvalid = 0x2602,
        ThresholdParametersNotSupported = 0x2603,
        InvalidReleaseOfPersistentReservation = 0x2604,
        DataDecryptionError = 0x2605,
        TooManyTargetDescriptors = 0x2606,
        UnsupportedTargetDescriptorTypeCode = 0x2607,
        TooManySegmentDescriptors = 0x2608,
        UnsupportedSegmentDescriptorTypeCode = 0x2609,
        UnexpectedInexactSegment = 0x260A,
        InlineDataLengthExceeded = 0x260B,
        InvalidOperationForCopySourceOrDestination = 0x260C,
        CopySegmentGranularityViolation = 0x260D,
        InvalidParameterWhilePortIsEnabled = 0x260E,
        InvalidDataOutBufferIntegrityCheckValue = 0x260F,
        DataDecryptionKeyFailLimitReached = 0x2610,
        IncompleteKeyAssociatedDataSet = 0x2611,
        VendorSpecificKeyReferenceNotFound = 0x2612,
        WriteProtected = 0x2700,
        HardwareWriteProtected = 0x2701,
        LogicalUnitSoftwareWriteProtected = 0x2702,
        AssociatedWriteProtect = 0x2703,
        PersistentWriteProtect = 0x2704,
        PermanentWriteProtect = 0x2705,
        ConditionalWriteProtect = 0x2706,
        SpaceAllocationFailedWriteProtect = 0x2707,
        NotReadyToReadyChange_MediumMayHaveChanged = 0x2800,
        ImportOrExportElementAccessed = 0x2801,
        FormatLayerMayHaveChanged = 0x2802,
        ImportOrExportElementAccessed_MediumChanged = 0x2803,
        PowerOn_Reset,
        OrBusDeviceResetOccurred = 0x2900,
        PowerOnOccurred = 0x2901,
        ScsiBusResetOccurred = 0x2902,
        BusDeviceResetFunctionOccurred = 0x2903,
        DeviceInternalReset = 0x2904,
        TransceiverModeChangedToSingleEnded = 0x2905,
        TransceiverModeChangedToLvd = 0x2906,
        I_TNexusLossOccurred = 0x2907,
        ParametersChanged = 0x2A00,
        ModeParametersChanged = 0x2A01,
        LogParametersChanged = 0x2A02,
        ReservationsPreempted = 0x2A03,
        ReservationsReleased = 0x2A04,
        RegistrationsPreempted = 0x2A05,
        AsymmetricAccessStateChanged = 0x2A06,
        ImplicitAsymmetricAccessStateTransitionFailed = 0x2A07,
        PriorityChanged = 0x2A08,
        CapacityDataHasChanged = 0x2A09,
        ErrorHistoryI_TNexusCleared = 0x2A0A,
        ErrorHistorySnapshotReleased = 0x2A0B,
        ErrorRecoveryAttributesHaveChanged = 0x2A0C,
        DataEncryptionCapabilitiesChanged = 0x2A0D,
        TimestampChanged = 0x2A10,
        DataEncryptionParametersChangedByAnotherI_TNexus = 0x2A11,
        DataEncryptionParametersChangedByVendorSpecificEvent = 0x2A12,
        DataEncryptionKeyInstanceCounterHasChanged = 0x2A13,
        SaCreationCapabilitiesDataHasChanged = 0x2A14,
        CopyCannotExecuteSinceHostCannotDisconnect = 0x2B00,
        CommandSequenceError = 0x2C00,
        TooManyWindowsSpecified = 0x2C01,
        InvalidCombinationOfWindowsSpecified = 0x2C02,
        CurrentProgramAreaIsNotEmpty = 0x2C03,
        CurrentProgramAreaIsEmpty = 0x2C04,
        IllegalPowerConditionRequest = 0x2C05,
        PersistentPreventConflict = 0x2C06,
        PreviousBusyStatus = 0x2C07,
        PreviousTaskSetFullStatus = 0x2C08,
        PreviousReservationConflictStatus = 0x2C09,
        PartitionOrCollectionContainsUserObjects = 0x2C0A,
        NotReserved = 0x2C0B,
        OverwriteErrorOnUpdateInPlace = 0x2D00,
        InsufficientTimeForOperation = 0x2E00,
        CommandsClearedByAnotherInitiator = 0x2F00,
        CommandsClearedByPowerLossNotification = 0x2F01,
        CommandsClearedByDeviceServer = 0x2F02,
        IncompatibleMediumInstalled = 0x3000,
        CannotReadMediumUnknownFormat = 0x3001,
        CannotReadMediumIncompatibleFormat = 0x3002,
        CleaningCartridgeInstalled = 0x3003,
        CannotWriteMediumUnknownFormat = 0x3004,
        CannotWriteMediumIncompatibleFormat = 0x3005,
        CannotFormatMediumIncompatibleMedium = 0x3006,
        CleaningFailure = 0x3007,
        CannotWriteApplicationCodeMismatch = 0x3008,
        CurrentSessionNotFixatedForAppend = 0x3009,
        CleaningRequestRejected = 0x300A,
        WormMediumOverwriteAttempted = 0x300C,
        WormMediumIntegrityCheck = 0x300D,
        MediumNotFormatted = 0x3010,
        IncompatibleVolumeType = 0x3011,
        IncompatibleVolumeQualifier = 0x3012,
        CleaningVolumeExpired = 0x3013,
        MediumFormatCorrupted = 0x3100,
        FormatCommandFailed = 0x3101,
        ZonedFormattingFailedDueToSpareLinking = 0x3102,
        NoDefectSpareLocationAvailable = 0x3200,
        DefectListUpdateFailure = 0x3201,
        TapeLengthError = 0x3300,
        EnclosureFailure = 0x3400,
        EnclosureServicesFailure = 0x3500,
        UnsupportedEnclosureFunction = 0x3501,
        EnclosureServicesUnavailable = 0x3502,
        EnclosureServicesTransferFailure = 0x3503,
        EnclosureServicesTransferRefused = 0x3504,
        EnclosureServicesChecksumError = 0x3505,
        Ribbon_Ink,
        OrTonerFailure = 0x3600,
        RoundedParameter = 0x3700,
        EventStatusNotification = 0x3800,
        EsnPowerManagementClassEvent = 0x3802,
        EsnMediaClassEvent = 0x3804,
        EsnDeviceBusyClassEvent = 0x3806,
        ThinProvisioningSoftThresholdReached = 0x3807,
        SavingParametersNotSupported = 0x3900,
        MediumNotPresent = 0x3A00,
        MediumNotPresentTrayClosed = 0x3A01,
        MediumNotPresentTrayOpen = 0x3A02,
        MediumNotPresentLoadable = 0x3A03,
        MediumNotPresentMediumAuxiliaryMemoryAccessible = 0x3A04,
        SequentialPositioningError = 0x3B00,
        TapePositionErrorAtBeginningOfMedium = 0x3B01,
        TapePositionErrorAtEndOfMedium = 0x3B02,
        TapeOrElectronicVerticalFormsUnitNotReady = 0x3B03,
        SlewFailure = 0x3B04,
        PaperJam = 0x3B05,
        FailedToSenseTopOfForm = 0x3B06,
        FailedToSenseBottomOfForm = 0x3B07,
        RepositionError = 0x3B08,
        ReadPastEndOfMedium = 0x3B09,
        ReadPastBeginningOfMedium = 0x3B0A,
        PositionPastEndOfMedium = 0x3B0B,
        PositionPastBeginningOfMedium = 0x3B0C,
        MediumDestinationElementFull = 0x3B0D,
        MediumSourceElementEmpty = 0x3B0E,
        EndOfMediumReached = 0x3B0F,
        MediumMagazineNotAccessible = 0x3B11,
        MediumMagazineRemoved = 0x3B12,
        MediumMagazineInserted = 0x3B13,
        MediumMagazineLocked = 0x3B14,
        MediumMagazineUnlocked = 0x3B15,
        MechanicalPositioningOrChangerError = 0x3B16,
        ReadPastEndOfUserObject = 0x3B17,
        ElementDisabled = 0x3B18,
        ElementEnabled = 0x3B19,
        DataTransferDeviceRemoved = 0x3B1A,
        DataTransferDeviceInserted = 0x3B1B,
        InvaliDefectiveBlockInformationtsInIdentifyMessage = 0x3D00,
        LogicalUnitHasNotSelfConfiguredYet = 0x3E00,
        LogicalUnitFailure = 0x3E01,
        TimeoutOnLogicalUnit = 0x3E02,
        LogicalUnitFailedSelfTest = 0x3E03,
        LogicalUnitUnableToUpdateSelfTestLog = 0x3E04,
        TargetOperatingConditionsHaveChanged = 0x3F00,
        MicrocodeHasBeenChanged = 0x3F01,
        ChangedOperatingDefinition = 0x3F02,
        InquiryDataHasChanged = 0x3F03,
        ComponentDeviceAttached = 0x3F04,
        DeviceIdentifierChanged = 0x3F05,
        RedundancyGroupCreatedOrModified = 0x3F06,
        RedundancyGroupDeleted = 0x3F07,
        SpareCreatedOrModified = 0x3F08,
        SpareDeleted = 0x3F09,
        VolumeSetCreatedOrModified = 0x3F0A,
        VolumeSetDeleted = 0x3F0B,
        VolumeSetDeassigned = 0x3F0C,
        VolumeSetReassigned = 0x3F0D,
        ReportedLunsDataHasChanged = 0x3F0E,
        EchoBufferOverwritten = 0x3F0F,
        MediumLoadable = 0x3F10,
        MediumAuxiliaryMemoryAccessible = 0x3F11,
        IscsiIpAddressAdded = 0x3F12,
        IscsiIpAddressRemoved = 0x3F13,
        IscsiIpAddressChanged = 0x3F14,
        RamFailure_ShouldUse40NN = 0x4000, //0x40NN
        //DiagnosticFailureOnComponentNn(0x80FF)
        //DataPathFailure(ShouldUse40Nn) = 0x4100,
        //PowerOnOrSelfTestFailure(ShouldUse40Nn) = 0x4200,
        MessageError = 0x4300,
        InternalTargetFailure = 0x4400,
        AtaDeviceFailedSetFeatures = 0x4471,
        SelectOrReselectFailure = 0x4500,
        UnsuccessfulSoftReset = 0x4600,
        ScsiParityError = 0x4700,
        DataPhaseCrcErrorDetected = 0x4701,
        ScsiParityErrorDetectedDuringStDataPhase = 0x4702,
        InformationUnitIucrcErrorDetected = 0x4703,
        AsynchronousInformationProtectionErrorDetected = 0x4704,
        ProtocolServiceCrcError = 0x4705,
        PhyTestFunctionInProgress = 0x4706,
        SomeCommandsClearedByIscsiProtocolEvent = 0x477F,
        InitiatorDetectedErrorMessageReceived = 0x4800,
        InvalidMessageError = 0x4900,
        CommandPhaseError = 0x4A00,
        DataPhaseError = 0x4B00,
        InvalidTargetPortTransferTagReceived = 0x4B01,
        TooMuchWriteData = 0x4B02,
        AckOrNakTimeout = 0x4B03,
        NakReceived = 0x4B04,
        DataOffsetError = 0x4B05,
        InitiatorResponseTimeout = 0x4B06,
        ConnectionLost = 0x4B07,
        LogicalUnitFailedSelfConfiguration = 0x4C00,
        //0x4DNN
        //TaggedOverlappedCommands(Nn = TaskTag)
        OverlappedCommandsAttempted = 0x4E00,
        WriteAppendError = 0x5000,
        WriteAppendPositionError = 0x5001,
        PositionErrorRelatedToTiming = 0x5002,
        EraseFailure = 0x5100,
        EraseFailureIncompleteEraseOperationDetected = 0x5101,
        CartridgeFault = 0x5200,
        MediaLoadOrEjectFailed = 0x5300,
        UnloadTapeFailure = 0x5301,
        MediumRemovalPrevented = 0x5302,
        MediumRemovalPreventedByDataTransferElement = 0x5303,
        MediumThreadOrUnthreadFailure = 0x5304,
        ScsiToHostSystemInterfaceFailure = 0x5400,
        SystemResourceFailure = 0x5500,
        SystemBufferFull = 0x5501,
        InsufficientReservationResources = 0x5502,
        InsufficientResources = 0x5503,
        InsufficientRegistrationResources = 0x5504,
        InsufficientAccessControlResources = 0x5505,
        AuxiliaryMemoryOutOfSpace = 0x5506,
        QuotaError = 0x5507,
        MaximumNumberOfSupplementalDecryptionKeysExceeded = 0x5508,
        MediumAuxiliaryMemoryNotAccessible = 0x5509,
        DataCurrentlyUnavailable = 0x550A,
        InsufficientPowerForOperation = 0x550B,
        UnableToRecoverTableOfContents = 0x5700,
        GenerationDoesNotExist = 0x5800,
        UpdatedBlockRead = 0x5900,
        OperatorRequestOrStateChangeInput = 0x5A00,
        OperatorMediumRemovalRequest = 0x5A01,
        OperatorSelectedWriteProtect = 0x5A02,
        OperatorSelectedWritePermit = 0x5A03,
        LogException = 0x5B00,
        ThresholdConditionMet = 0x5B01,
        LogCounterAtMaximum = 0x5B02,
        LogListCodesExhausted = 0x5B03,
        RplStatusChange = 0x5C00,
        SpindlesSynchronized = 0x5C01,
        SpindlesNotSynchronized = 0x5C02,
        FailurePredictionThresholdExceeded = 0x5D00,
        MediaFailurePredictionThresholdExceeded = 0x5D01,
        LogicalUnitFailurePredictionThresholdExceeded = 0x5D02,
        SpareAreaExhaustionPredictionThresholdExceeded = 0x5D03,
        HardwareImpendingFailureGeneralHardDriveFailure = 0x5D10,
        HardwareImpendingFailureDriveErrorRateTooHigh = 0x5D11,
        HardwareImpendingFailureDataErrorRateTooHigh = 0x5D12,
        HardwareImpendingFailureSeekErrorRateTooHigh = 0x5D13,
        HardwareImpendingFailureTooManyBlockReassigns = 0x5D14,
        HardwareImpendingFailureAccessTimesTooHigh = 0x5D15,
        HardwareImpendingFailureStartUnitTimesTooHigh = 0x5D16,
        HardwareImpendingFailureChannelParametrics = 0x5D17,
        HardwareImpendingFailureControllerDetected = 0x5D18,
        HardwareImpendingFailureThroughputPerformance = 0x5D19,
        HardwareImpendingFailureSeekTimePerformance = 0x5D1A,
        HardwareImpendingFailureSpinUpRetryCount = 0x5D1B,
        HardwareImpendingFailureDriveCalibrationRetryCount = 0x5D1C,
        ControllerImpendingFailureGeneralHardDriveFailure = 0x5D20,
        ControllerImpendingFailureDriveErrorRateTooHigh = 0x5D21,
        ControllerImpendingFailureDataErrorRateTooHigh = 0x5D22,
        ControllerImpendingFailureSeekErrorRateTooHigh = 0x5D23,
        ControllerImpendingFailureTooManyBlockReassigns = 0x5D24,
        ControllerImpendingFailureAccessTimesTooHigh = 0x5D25,
        ControllerImpendingFailureStartUnitTimesTooHigh = 0x5D26,
        ControllerImpendingFailureChannelParametrics = 0x5D27,
        ControllerImpendingFailureControllerDetected = 0x5D28,
        ControllerImpendingFailureThroughputPerformance = 0x5D29,
        ControllerImpendingFailureSeekTimePerformance = 0x5D2A,
        ControllerImpendingFailureSpinUpRetryCount = 0x5D2B,
        ControllerImpendingFailureDriveCalibrationRetryCount = 0x5D2C,
        DataChannelImpendingFailureGeneralHardDriveFailure = 0x5D30,
        DataChannelImpendingFailureDriveErrorRateTooHigh = 0x5D31,
        DataChannelImpendingFailureDataErrorRateTooHigh = 0x5D32,
        DataChannelImpendingFailureSeekErrorRateTooHigh = 0x5D33,
        DataChannelImpendingFailureTooManyBlockReassigns = 0x5D34,
        DataChannelImpendingFailureAccessTimesTooHigh = 0x5D35,
        DataChannelImpendingFailureStartUnitTimesTooHigh = 0x5D36,
        DataChannelImpendingFailureChannelParametrics = 0x5D37,
        DataChannelImpendingFailureControllerDetected = 0x5D38,
        DataChannelImpendingFailureThroughputPerformance = 0x5D39,
        DataChannelImpendingFailureSeekTimePerformance = 0x5D3A,
        DataChannelImpendingFailureSpinUpRetryCount = 0x5D3B,
        DataChannelImpendingFailureDriveCalibrationRetryCount = 0x5D3C,
        ServoImpendingFailureGeneralHardDriveFailure = 0x5D40,
        ServoImpendingFailureDriveErrorRateTooHigh = 0x5D41,
        ServoImpendingFailureDataErrorRateTooHigh = 0x5D42,
        ServoImpendingFailureSeekErrorRateTooHigh = 0x5D43,
        ServoImpendingFailureTooManyBlockReassigns = 0x5D44,
        ServoImpendingFailureAccessTimesTooHigh = 0x5D45,
        ServoImpendingFailureStartUnitTimesTooHigh = 0x5D46,
        ServoImpendingFailureChannelParametrics = 0x5D47,
        ServoImpendingFailureControllerDetected = 0x5D48,
        ServoImpendingFailureThroughputPerformance = 0x5D49,
        ServoImpendingFailureSeekTimePerformance = 0x5D4A,
        ServoImpendingFailureSpinUpRetryCount = 0x5D4B,
        ServoImpendingFailureDriveCalibrationRetryCount = 0x5D4C,
        SpindleImpendingFailureGeneralHardDriveFailure = 0x5D50,
        SpindleImpendingFailureDriveErrorRateTooHigh = 0x5D51,
        SpindleImpendingFailureDataErrorRateTooHigh = 0x5D52,
        SpindleImpendingFailureSeekErrorRateTooHigh = 0x5D53,
        SpindleImpendingFailureTooManyBlockReassigns = 0x5D54,
        SpindleImpendingFailureAccessTimesTooHigh = 0x5D55,
        SpindleImpendingFailureStartUnitTimesTooHigh = 0x5D56,
        SpindleImpendingFailureChannelParametrics = 0x5D57,
        SpindleImpendingFailureControllerDetected = 0x5D58,
        SpindleImpendingFailureThroughputPerformance = 0x5D59,
        SpindleImpendingFailureSeekTimePerformance = 0x5D5A,
        SpindleImpendingFailureSpinUpRetryCount = 0x5D5B,
        SpindleImpendingFailureDriveCalibrationRetryCount = 0x5D5C,
        FirmwareImpendingFailureGeneralHardDriveFailure = 0x5D60,
        FirmwareImpendingFailureDriveErrorRateTooHigh = 0x5D61,
        FirmwareImpendingFailureDataErrorRateTooHigh = 0x5D62,
        FirmwareImpendingFailureSeekErrorRateTooHigh = 0x5D63,
        FirmwareImpendingFailureTooManyBlockReassigns = 0x5D64,
        FirmwareImpendingFailureAccessTimesTooHigh = 0x5D65,
        FirmwareImpendingFailureStartUnitTimesTooHigh = 0x5D66,
        FirmwareImpendingFailureChannelParametrics = 0x5D67,
        FirmwareImpendingFailureControllerDetected = 0x5D68,
        FirmwareImpendingFailureThroughputPerformance = 0x5D69,
        FirmwareImpendingFailureSeekTimePerformance = 0x5D6A,
        FirmwareImpendingFailureSpinUpRetryCount = 0x5D6B,
        FirmwareImpendingFailureDriveCalibrationRetryCount = 0x5D6C,
        FailurePredictionThresholdExceededFalse = 0x5DFF,
        LowPowerConditionOn = 0x5E00,
        IdleConditionActivatedByTimer = 0x5E01,
        StandbyConditionActivatedByTimer = 0x5E02,
        IdleConditionActivatedByCommand = 0x5E03,
        StandbyConditionActivatedByCommand = 0x5E04,
        Idle_BConditionActivatedByTimer = 0x5E05,
        Idle_BConditionActivatedByCommand = 0x5E06,
        Idle_CConditionActivatedByTimer = 0x5E07,
        Idle_CConditionActivatedByCommand = 0x5E08,
        Standby_YConditionActivatedByTimer = 0x5E09,
        Standby_YConditionActivatedByCommand = 0x5E0A,
        PowerStateChangeToActive = 0x5E41,
        PowerStateChangeToIdle = 0x5E42,
        PowerStateChangeToStandby = 0x5E43,
        PowerStateChangeToSleep = 0x5E45,
        PowerStateChangeToDeviceControl = 0x5E47,
        LampFailure = 0x6000,
        VideoAcquisitionError = 0x6100,
        UnableToAcquireVideo = 0x6101,
        OutOfFocus = 0x6102,
        ScanHeadPositioningError = 0x6200,
        EndOfUserAreaEncounteredOnThisTrack = 0x6300,
        PacketDoesNotFitInAvailableSpace = 0x6301,
        IllegalModeForThisTrack = 0x6400,
        InvalidPacketSize = 0x6401,
        VoltageFault = 0x6500,
        AutomaticDocumentFeederCoverUp = 0x6600,
        AutomaticDocumentFeederLiftUp = 0x6601,
        DocumentJamInAutomaticDocumentFeeder = 0x6602,
        DocumentMissFeedAutomaticInDocumentFeeder = 0x6603,
        ConfigurationFailure = 0x6700,
        ConfigurationOfIncapableLogicalUnitsFailed = 0x6701,
        AddLogicalUnitFailed = 0x6702,
        ModificationOfLogicalUnitFailed = 0x6703,
        ExchangeOfLogicalUnitFailed = 0x6704,
        RemoveOfLogicalUnitFailed = 0x6705,
        AttachmentOfLogicalUnitFailed = 0x6706,
        CreationOfLogicalUnitFailed = 0x6707,
        AssignFailureOccurred = 0x6708,
        MultiplyAssignedLogicalUnit = 0x6709,
        SetTargetPortGroupsCommandFailed = 0x670A,
        AtaDeviceFeatureNotEnabled = 0x670B,
        LogicalUnitNotConfigured = 0x6800,
        DataLossOnLogicalUnit = 0x6900,
        MultipleLogicalUnitFailures = 0x6901,
        ParityOrDataMismatch = 0x6902,
        Informational_ReferToLog = 0x6A00,
        StateChangeHasOccurred = 0x6B00,
        RedundancyLevelGotBetter = 0x6B01,
        RedundancyLevelGotWorse = 0x6B02,
        RebuildFailureOccurred = 0x6C00,
        RecalculateFailureOccurred = 0x6D00,
        CommandToLogicalUnitFailed = 0x6E00,
        CopyProtectionKeyExchangeFailureAuthenticationFailure = 0x6F00,
        CopyProtectionKeyExchangeFailureKeyNotPresent = 0x6F01,
        CopyProtectionKeyExchangeFailureKeyNotEstablished = 0x6F02,
        ReadOfScrambledSectorWithoutAuthentication = 0x6F03,
        MediaRegionCodeIsMismatchedToLogicalUnitRegion = 0x6F04,
        DriveRegionMustBePermanentOrRegionResetCountError = 0x6F05,
        InsufficientBlockCountForBindingNonceRecording = 0x6F06,
        ConflictInBindingNonceRecording = 0x6F07,
        //0x70NNhT
        //DecompressionExceptionShortAlgorithmIdOfNn
        DecompressionExceptionLongAlgorithmId = 0x7100,
        SessionFixationError = 0x7200,
        SessionFixationErrorWritingLeadIn = 0x7201,
        SessionFixationErrorWritingLeadOut = 0x7202,
        SessionFixationErrorIncompleteTrackInSession = 0x7203,
        EmptyOrPartiallyWrittenReservedTrack = 0x7204,
        NoMoreTrackReservationsAllowed = 0x7205,
        RmzExtensionIsNotAllowed = 0x7206,
        NoMoreTestZoneExtensionsAreAllowed = 0x7207,
        CdControlError = 0x7300,
        PowerCalibrationAreaAlmostFull = 0x7301,
        PowerCalibrationAreaIsFull = 0x7302,
        PowerCalibrationAreaError = 0x7303,
        ProgramMemoryAreaUpdateFailure = 0x7304,
        ProgramMemoryAreaIsFull = 0x7305,
        RmaOrPmaIsAlmostFull = 0x7306,
        CurrentPowerCalibrationAreaAlmostFull = 0x7310,
        CurrentPowerCalibrationAreaIsFull = 0x7311,
        RdzIsFull = 0x7317,
        SecurityError = 0x7400,
        UnableToDecryptData = 0x7401,
        UnencryptedDataEncounteredWhileDecrypting = 0x7402,
        IncorrectDataEncryptionKey = 0x7403,
        CryptographicIntegrityValidationFailed = 0x7404,
        ErrorDecryptingData = 0x7405,
        UnknownSignatureVerificationKey = 0x7406,
        EncryptionParametersNotUseable = 0x7407,
        DigitalSignatureValidationFailure = 0x7408,
        EncryptionModeMismatchOnRead = 0x7409,
        EncryptedBlockNotRawReadEnabled = 0x740A,
        IncorrectEncryptionParameters = 0x740B,
        UnableToDecryptParameterList = 0x740C,
        EncryptionAlgorithmDisabled = 0x740D,
        SaCreationParameterValueInvalid = 0x7410,
        SaCreationParameterValueRejected = 0x7411,
        InvalidSaUsage = 0x7412,
        DataEncryptionConfigurationPrevented = 0x7421,
        SaCreationParameterNotSupported = 0x7430,
        AuthenticationFailed = 0x7440,
        ExternalDataEncryptionKeyManagerAccessError = 0x7461,
        ExternalDataEncryptionKeyManagerError = 0x7462,
        ExternalDataEncryptionKeyNotFound = 0x7463,
        ExternalDataEncryptionRequestNotAuthorized = 0x7464,
        ExternalDataEncryptionControlTimeout = 0x746E,
        ExternalDataEncryptionControlError = 0x746F,
        LogicalUnitAccessNotAuthorized = 0x7471,
        SecurityConflictInTranslatedDevice = 0x7479,
    }
}