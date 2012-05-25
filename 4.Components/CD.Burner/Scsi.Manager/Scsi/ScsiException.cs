using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;

namespace Scsi
{
    [Serializable]
    public class ScsiException : Exception
    {
        [NonSerialized] private bool msgProvided;

        public ScsiException() : this(new SenseData())
        {
        }

        public ScsiException(string message) : this(new SenseData(), message)
        {
        }

        public ScsiException(string message, Exception innerException) : this(new SenseData(), message, innerException)
        {
        }

        public ScsiException(SenseData senseData) : this(senseData, null)
        {
        }

        public ScsiException(SenseData senseData, string message) : this(senseData, message, null)
        {
        }

        public ScsiException(SenseData senseData, string message, Exception innerException)
            : base(message, innerException)
        {
            SenseData = senseData;
            msgProvided = message != null;
        }

        protected ScsiException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        public SenseData SenseData { get; private set; }

        public override string Message
        {
            get
            {
                if (!msgProvided)
                {
                    SenseData senseData = SenseData;
                    var optionals = new List<string>();
                    if (senseData.IncorrectLengthIndicator)
                    {
                        optionals.Add("Incorrect Length");
                    }
                    if (senseData.EndOfMedium)
                    {
                        optionals.Add("End of Medium");
                    }
                    if (senseData.FileMark)
                    {
                        optionals.Add("File Mark");
                    }
                    object senseKeySpecific = senseData.GetSenseKeySpecificBytes();
                    if (senseKeySpecific != null)
                    {
                        optionals.Add(senseKeySpecific.ToString());
                    }
                    return string.Format("{0}: {1}" + Environment.NewLine + "{2}{3}",
                                         GetString(senseData.ResponseCode), GetString(senseData.SenseKey),
                                         GetMessage(senseData.SenseKey, senseData.AdditionalSenseCodeAndQualifier),
                                         optionals.Count > 0
                                             ? string.Format(" ({0})", string.Join(", ", optionals.ToArray()))
                                             : string.Empty);
                }
                else
                {
                    return base.Message;
                }
            }
        }

        private static string GetString(SenseKey sk)
        {
            switch (sk)
            {
                case SenseKey.NoSense:
                    return "No Sense";
                case SenseKey.RecoveredError:
                    return "Recovered Error";
                case SenseKey.NotReady:
                    return "Not Ready";
                case SenseKey.MediumError:
                    return "Medium Error";
                case SenseKey.HardwareError:
                    return "Hardware Error";
                case SenseKey.IllegalRequest:
                    return "Illegal Request";
                case SenseKey.UnitAttention:
                    return "Unit Attention";
                case SenseKey.DataProtect:
                    return "Data Protect";
                case SenseKey.BlankCheck:
                    return "Blank Check";
                case SenseKey.VendorSpecific:
                    return "Vendor-Specific";
                case SenseKey.CopyAborted:
                    return "Copy Aborted";
                case SenseKey.AbortedCommand:
                    return "Aborted Command";
                case SenseKey.VolumeOverflow:
                    return "Volume Overflow";
                case SenseKey.Miscompare:
                    return "Miscompare";
                default:
                    return string.Format("Sense Key {0}", sk);
            }
        }

        private static string GetString(ResponseCode responseCode)
        {
            switch (responseCode)
            {
                case ResponseCode.CurrentError:
                    return "Current Error";
                case ResponseCode.DeferredError:
                    return "Deferred Error";
                case ResponseCode.VendorSpecific:
                    return "Vendor-specific Error";
                default:
                    return "No Response Code";
            }
        }

        public static string GetMessage(SenseKey sk, AdditionalSenseInformation senseInfo)
        {
            switch (senseInfo)
            {
                case AdditionalSenseInformation.NoAdditionalSenseInformation:
                    return "No additional sense information";
                case AdditionalSenseInformation.Warning:
                    return "Warning";
                case AdditionalSenseInformation.WarningSpecifiedTemperatureExceeded:
                    return "Warning - specified temperature exceeded";
                case AdditionalSenseInformation.WarningEnclosureDegraded:
                    return "Warning - enclosure degraded";
                case AdditionalSenseInformation.WarningBackgroundSelfTestFailed:
                    return "Warning - background self-test failed";
                case AdditionalSenseInformation.WarningBackgroundPreScanDetectedMediumError:
                    return "Warning - background pre-scan detected medium error";
                case AdditionalSenseInformation.WarningBackgroundMediumScanDetectedMediumError:
                    return "Warning - background medium scan detected medium error";
                case AdditionalSenseInformation.WriteErrorRecoveredWithAutoReallocation:
                    return "Write error - recovered with auto-reallocation";
                case AdditionalSenseInformation.RecoveredDataWithNoErrorCorrectionApplied:
                    return "Recovered data with no error correction applied";
                case AdditionalSenseInformation.RecoveredDataWithRetries:
                    return "Recovered data with retries";
                case AdditionalSenseInformation.RecoveredDataWithPositiveHeadOffset:
                    return "Recovered data with positive head offset";
                case AdditionalSenseInformation.RecoveredDataWithNegativeHeadOffset:
                    return "Recovered data with negative head offset";
                case AdditionalSenseInformation.RecoveredDataWithRetriesOrCircApplied:
                    return "Recovered data with retries and/or circ applied";
                case AdditionalSenseInformation.RecoveredDataUsingPreviousSectorId:
                    return "Recovered data using previous sector id";
                case AdditionalSenseInformation.RecoveredDataWithoutEccRecommendReassignment:
                    return "Recovered data without ECC - recommend reassignment";
                case AdditionalSenseInformation.RecoveredDataWithoutEccRecommendRewrite:
                    return "Recovered data without ECC - recommend rewrite";
                case AdditionalSenseInformation.RecoveredDataWithoutEccDataRewritten:
                    return "Recovered data without ECC - data rewritten";
                case AdditionalSenseInformation.RecoveredDataWithErrorCorrectionApplied:
                    return "Recovered data with error correction applied";
                case AdditionalSenseInformation.RecoveredDataWithErrorCorrectionAndRetriesApplied:
                    return "Recovered data with error correction & retries applied";
                case AdditionalSenseInformation.RecoveredDataDataAutoReallocated:
                    return "Recovered data - data auto-reallocated";
                case AdditionalSenseInformation.RecoveredDataWithCirc:
                    return "Recovered data with circ";
                case AdditionalSenseInformation.RecoveredDataWithLEc:
                    return "Recovered data with L-EC";
                case AdditionalSenseInformation.RecoveredDataRecommendReassignment:
                    return "Recovered data - recommend reassignment";
                case AdditionalSenseInformation.RecoveredDataRecommendRewrite:
                    return "Recovered data - recommend rewrite";
                case AdditionalSenseInformation.RecoveredDataWithLinking:
                    return "Recovered data with linking";
                case AdditionalSenseInformation.RoundedParameter:
                    return "Rounded parameter";
                case AdditionalSenseInformation.FailurePredictionThresholdExceeded:
                    return "Failure prediction threshold exceeded";
                case AdditionalSenseInformation.MediaFailurePredictionThresholdExceeded:
                    return "Failure prediction threshold exceeded - predicted media failure";
                case AdditionalSenseInformation.LogicalUnitFailurePredictionThresholdExceeded:
                    return "Logical unit failure prediction threshold exceeded";
                case AdditionalSenseInformation.SpareAreaExhaustionPredictionThresholdExceeded:
                    return "Failure prediction threshold exceeded - predicted spare area exhaustion";
                case AdditionalSenseInformation.FailurePredictionThresholdExceededFalse:
                    return "Failure prediction threshold exceeded (false)";
                case AdditionalSenseInformation.PowerCalibrationAreaAlmostFull:
                    return "Power calibration area almost full";
                case AdditionalSenseInformation.RmaOrPmaIsAlmostFull:
                    return "RMA/PMA is almost full";
                case AdditionalSenseInformation.LogicalUnitNotReady_CauseNotReportable:
                    return "Logical unit not ready, cause not reportable";
                case AdditionalSenseInformation.LogicalUnitIsInProcessOfBecomingReady:
                    return "Logical unit is in process of becoming ready";
                case AdditionalSenseInformation.LogicalUnitNotReady_InitializingCommandRequired:
                    return "Logical unit not ready, initializing cmd. required";
                case AdditionalSenseInformation.LogicalUnitNotReady_ManualInterventionRequired:
                    return "Logical unit not ready, manual intervention required";
                case AdditionalSenseInformation.LogicalUnitNotReady_FormatInProgress:
                    return "Logical unit not ready, format in progress";
                case AdditionalSenseInformation.LogicalUnitNotReady_OperationInProgress:
                    return "Logical unit not ready, operation in progress";
                case AdditionalSenseInformation.LogicalUnitNotReady_LongWriteInProgress:
                    return "Logical unit not ready, long write in progress";
                case AdditionalSenseInformation.LogicalUnitNotReady_SelfTestInProgress:
                    return "Logical unit not ready, self-test in progress";
                case AdditionalSenseInformation.WriteErrorRecoveryNeeded:
                    return "Write error - recovery needed";
                case AdditionalSenseInformation.DefectsInErrorWindow:
                    return "Defects in error window";
                case AdditionalSenseInformation.IncompatibleMediumInstalled:
                    return "Incompatible medium installed";
                case AdditionalSenseInformation.CannotReadMediumUnknownFormat:
                    return "Cannot read medium - unknown format";
                case AdditionalSenseInformation.CannotReadMediumIncompatibleFormat:
                    return "Cannot read medium - incompatible format";
                case AdditionalSenseInformation.CleaningCartridgeInstalled:
                    return "Cleaning cartridge installed";
                case AdditionalSenseInformation.CannotWriteMediumUnknownFormat:
                    return "Cannot write medium - unknown format";
                case AdditionalSenseInformation.CannotWriteMediumIncompatibleFormat:
                    return "Cannot write medium - incompatible format";
                case AdditionalSenseInformation.CannotFormatMediumIncompatibleMedium:
                    return "Cannot format medium - incompatible medium";
                case AdditionalSenseInformation.CleaningFailure:
                    return "Cleaning failure";
                case AdditionalSenseInformation.IncompatibleVolumeType:
                    return "Cannot write medium - unsupported medium version";
                case AdditionalSenseInformation.MediumNotPresent:
                    return "Medium not present";
                case AdditionalSenseInformation.MediumNotPresentTrayClosed:
                    return "Medium not present - tray closed";
                case AdditionalSenseInformation.MediumNotPresentTrayOpen:
                    return "Medium not present - tray open";
                case AdditionalSenseInformation.MediumNotPresentLoadable:
                    return "Medium not present - loadable";
                case AdditionalSenseInformation.LogicalUnitHasNotSelfConfiguredYet:
                    return "Logical unit has not self-configured yet";
                case AdditionalSenseInformation.NoSeekComplete:
                    return "No seek complete";
                case AdditionalSenseInformation.NoReferencePositionFound:
                    return "No reference position found";
                case AdditionalSenseInformation.WriteError:
                    return "Write error";
                case AdditionalSenseInformation.WriteErrorAutoReallocationFailed:
                    return "Write error - auto-reallocation failed";
                case AdditionalSenseInformation.WriteErrorRecommendReassignment:
                    return "Write error - recommend reassignment";
                case AdditionalSenseInformation.WriteErrorRecoveryFailed:
                    return "Write error - recovery failed";
                case AdditionalSenseInformation.WriteErrorLossOfStreaming:
                    return "Write error - loss of streaming";
                case AdditionalSenseInformation.WriteErrorPaddingBlocksAdded:
                    return "Write error - padding blocks added";
                case AdditionalSenseInformation.UnrecoveredReadError:
                    return "Unrecovered read error";
                case AdditionalSenseInformation.ReadRetriesExhausted:
                    return "Read retries exhausted";
                case AdditionalSenseInformation.ErrorTooLongToCorrect:
                    return "Error too long to correct";
                case AdditionalSenseInformation.LEcUncorrectableError:
                    return "L-EC uncorrectable error";
                case AdditionalSenseInformation.CircUnrecoveredError:
                    return "Circ unrecovered error";
                case AdditionalSenseInformation.ErrorReadingUpcOrEanNumber:
                    return "Error reading UPC/EAN number";
                case AdditionalSenseInformation.ErrorReadingIsrcNumber:
                    return "Error reading ISRC number";
                case AdditionalSenseInformation.RandomPositioningError:
                    return "Random positioning error";
                case AdditionalSenseInformation.MechanicalPositioningError:
                    return "Mechanical positioning error";
                case AdditionalSenseInformation.PositioningErrorDetectedByReadOfMedium:
                    return "Positioning error detected by read of medium";
                case AdditionalSenseInformation.MediumFormatCorrupted:
                    return "Medium format corrupted";
                case AdditionalSenseInformation.FormatCommandFailed:
                    return "Format command failed";
                case AdditionalSenseInformation.ZonedFormattingFailedDueToSpareLinking:
                    return "Zoned formatting failed due to spare linking";
                case AdditionalSenseInformation.NoDefectSpareLocationAvailable:
                    return "No defect spare location available";
                case AdditionalSenseInformation.EraseFailure:
                    return "Erase failure";
                case AdditionalSenseInformation.EraseFailureIncompleteEraseOperationDetected:
                    return "Erase failure - incomplete erase operation detected";
                case AdditionalSenseInformation.UnableToRecoverTableOfContents:
                    return "Unable to recover table-of-contents";
                case AdditionalSenseInformation.SessionFixationError:
                    return "Session fixation error";
                case AdditionalSenseInformation.SessionFixationErrorWritingLeadIn:
                    return "Session fixation error writing lead-in";
                case AdditionalSenseInformation.SessionFixationErrorWritingLeadOut:
                    return "Session fixation error writing lead-out";
                case AdditionalSenseInformation.CdControlError:
                    return "Cd control error";
                case AdditionalSenseInformation.PowerCalibrationAreaIsFull:
                    return "Power calibration area is full";
                case AdditionalSenseInformation.PowerCalibrationAreaError:
                    return "Power calibration area error";
                case AdditionalSenseInformation.ProgramMemoryAreaUpdateFailure:
                    return "Program memory area update failure";
                case AdditionalSenseInformation.ProgramMemoryAreaIsFull:
                    return "Program memory area is full";
                case AdditionalSenseInformation.CurrentPowerCalibrationAreaAlmostFull:
                    return "Current power calibration area is almost full";
                case AdditionalSenseInformation.CurrentPowerCalibrationAreaIsFull:
                    return "Current power calibration area is full";
                case AdditionalSenseInformation.CleaningRequested:
                    return "Cleaning requested";
                case AdditionalSenseInformation.LogicalUnitDoesNotRespondToSelection:
                    return "Logical unit does not respond to selection";
                case AdditionalSenseInformation.LogicalUnitCommunicationFailure:
                    return "Logical unit communication failure";
                case AdditionalSenseInformation.LogicalUnitCommunicationTimeOut:
                    return "Logical unit communication timeout";
                case AdditionalSenseInformation.LogicalUnitCommunicationParityError:
                    return "Logical unit communication parity error";
                case AdditionalSenseInformation.LogicalUnitCommunicationCrcError_UltraDma32:
                    return "Logical unit communication CRC error (Ultra-DMA/32)";
                case AdditionalSenseInformation.TrackFollowingError:
                    return "Track following error";
                case AdditionalSenseInformation.TrackingServoFailure:
                    return "Tracking servo failure";
                case AdditionalSenseInformation.FocusServoFailure:
                    return "Focus servo failure";
                case AdditionalSenseInformation.SpindleServoFailure:
                    return "Spindle servo failure";
                case AdditionalSenseInformation.HeadSelectFault:
                    return "Head select fault";
                case AdditionalSenseInformation.SynchronousDataTransferError:
                    return "Synchronous data transfer error";
                case AdditionalSenseInformation.MechanicalPositioningOrChangerError:
                    return "Mechanical positioning or changer error";
                case AdditionalSenseInformation.LogicalUnitFailure:
                    return "Logical unit failure";
                case AdditionalSenseInformation.TimeoutOnLogicalUnit:
                    return "Timeout on logical unit";
                case AdditionalSenseInformation.InternalTargetFailure:
                    return "Internal target failure";
                case AdditionalSenseInformation.UnsuccessfulSoftReset:
                    return "Unsuccessful soft reset";
                case AdditionalSenseInformation.ScsiParityError:
                    return "Scsi parity error";
                case AdditionalSenseInformation.CommandPhaseError:
                    return "Command phase error";
                case AdditionalSenseInformation.DataPhaseError:
                    return "Data phase error";
                case AdditionalSenseInformation.LogicalUnitFailedSelfConfiguration:
                    return "Logical unit failed self-configuration";
                case AdditionalSenseInformation.MediaLoadOrEjectFailed:
                    return "Media load or eject failed";
                case AdditionalSenseInformation.VoltageFault:
                    return "Voltage fault";
                case AdditionalSenseInformation.OperationInProgress:
                    return "Operation in progress";
                case AdditionalSenseInformation.MultiplePeripheralDevicesSelected:
                    return "Multiple peripheral devices selected";
                case AdditionalSenseInformation.ParameterListLengthError:
                    return "Parameter list length error";
                case AdditionalSenseInformation.InvalidCommandOperationCode:
                    return "Invalid command operation code";
                case AdditionalSenseInformation.LogicalBlockAddressOutOfRange:
                    return "Logical block address out of range";
                case AdditionalSenseInformation.InvalidElementAddress:
                    return "Invalid element address";
                case AdditionalSenseInformation.InvalidAddressForWrite:
                    return "Invalid address for write";
                case AdditionalSenseInformation.InvalidWriteCrossingLayerJump:
                    return "Invalid write crossing layer jump";
                case AdditionalSenseInformation.IllegalFunction_Use2000Or2400Or2600:
                    return "Illegal function";
                case AdditionalSenseInformation.InvalidFieldInCdb:
                    return "Invalid field in CDB";
                case AdditionalSenseInformation.LogicalUnitNotSupported:
                    return "Logical unit not supported";
                case AdditionalSenseInformation.InvalidFieldInParameterList:
                    return "Invalid field in parameter list";
                case AdditionalSenseInformation.ParameterNotSupported:
                    return "Parameter not supported";
                case AdditionalSenseInformation.ParameterValueInvalid:
                    return "Parameter value invalid";
                case AdditionalSenseInformation.ThresholdParametersNotSupported:
                    return "Threshold parameters not supported";
                case AdditionalSenseInformation.InvalidReleaseOfPersistentReservation:
                    return "Invalid release of persistent reservation";
                case AdditionalSenseInformation.CopyCannotExecuteSinceHostCannotDisconnect:
                    return "Copy cannot execute since initiator cannot disconnect";
                case AdditionalSenseInformation.CommandSequenceError:
                    return "Command sequence error";
                case AdditionalSenseInformation.CurrentProgramAreaIsNotEmpty:
                    return "Current program area is not empty";
                case AdditionalSenseInformation.CurrentProgramAreaIsEmpty:
                    return "Current program area is empty";
                case AdditionalSenseInformation.CannotWriteApplicationCodeMismatch:
                    return "Cannot write - application code mismatch";
                case AdditionalSenseInformation.CurrentSessionNotFixatedForAppend:
                    return "Current session not fixated for append";
                case AdditionalSenseInformation.MediumNotFormatted:
                    return "Medium not formatted";
                case AdditionalSenseInformation.SavingParametersNotSupported:
                    return "Saving parameters not supported";
                case AdditionalSenseInformation.InvaliDefectiveBlockInformationtsInIdentifyMessage:
                    return "Invalid bits in identify message";
                case AdditionalSenseInformation.MessageError:
                    return "Message error";
                case AdditionalSenseInformation.MediumRemovalPrevented:
                    return "Medium removal prevented";
                case AdditionalSenseInformation.SystemResourceFailure:
                    return "System resource failure";
                case AdditionalSenseInformation.EndOfUserAreaEncounteredOnThisTrack:
                    return "End of user area encountered on this track";
                case AdditionalSenseInformation.PacketDoesNotFitInAvailableSpace:
                    return "Packet does not fit in available space";
                case AdditionalSenseInformation.IllegalModeForThisTrack:
                    return "Illegal mode for this track";
                case AdditionalSenseInformation.InvalidPacketSize:
                    return "Invalid packet size";
                case AdditionalSenseInformation.CopyProtectionKeyExchangeFailureAuthenticationFailure:
                    return "Copy protection key exchange failure - authentication failure";
                case AdditionalSenseInformation.CopyProtectionKeyExchangeFailureKeyNotPresent:
                    return "Copy protection key exchange failure - key not present";
                case AdditionalSenseInformation.CopyProtectionKeyExchangeFailureKeyNotEstablished:
                    return "Copy protection key exchange failure -key not established";
                case AdditionalSenseInformation.ReadOfScrambledSectorWithoutAuthentication:
                    return "Read of scrambled sector without authentication";
                case AdditionalSenseInformation.MediaRegionCodeIsMismatchedToLogicalUnitRegion:
                    return "Media region code is mismatched to logical unit region";
                case AdditionalSenseInformation.DriveRegionMustBePermanentOrRegionResetCountError:
                    return "Logical unit region must be permanent/region reset count error";
                case AdditionalSenseInformation.InsufficientBlockCountForBindingNonceRecording:
                    return "Insufficient block count for binding nonce recording";
                case AdditionalSenseInformation.ConflictInBindingNonceRecording:
                    return "Conflict in binding nonce recording";
                case AdditionalSenseInformation.SessionFixationErrorIncompleteTrackInSession:
                    return "Session fixation error - incomplete track in session";
                case AdditionalSenseInformation.EmptyOrPartiallyWrittenReservedTrack:
                    return "Empty or partially written reserved track";
                case AdditionalSenseInformation.NoMoreTrackReservationsAllowed:
                    return "No more track reservations allowed";
                case AdditionalSenseInformation.RmzExtensionIsNotAllowed:
                    return "RMZ extension is not allowed";
                case AdditionalSenseInformation.NoMoreTestZoneExtensionsAreAllowed:
                    return "No more test zone extensions are allowed";
                case AdditionalSenseInformation.RdzIsFull:
                    return "RDZ is full";
                case AdditionalSenseInformation.ErrorLogOverflow:
                    return "Error log overflow";
                case AdditionalSenseInformation.NotReadyToReadyChange_MediumMayHaveChanged:
                    return "Not ready to ready change, medium may have changed";
                case AdditionalSenseInformation.ImportOrExportElementAccessed:
                    return "Import or export element accessed";
                case AdditionalSenseInformation.FormatLayerMayHaveChanged:
                    return "Format-layer may have changed";
                case AdditionalSenseInformation.OrBusDeviceResetOccurred:
                    return "Power on, reset, or bus device reset occurred";
                case AdditionalSenseInformation.PowerOnOccurred:
                    return "Power on occurred";
                case AdditionalSenseInformation.ScsiBusResetOccurred:
                    return "Bus reset occurred";
                case AdditionalSenseInformation.BusDeviceResetFunctionOccurred:
                    return "Bus device reset function occurred";
                case AdditionalSenseInformation.DeviceInternalReset:
                    return "Device internal reset";
                case AdditionalSenseInformation.ParametersChanged:
                    return "Parameters changed";
                case AdditionalSenseInformation.ModeParametersChanged:
                    return "Mode parameters changed";
                case AdditionalSenseInformation.LogParametersChanged:
                    return "Log parameters changed";
                case AdditionalSenseInformation.ReservationsPreempted:
                    return "Reservations preempted";
                case AdditionalSenseInformation.InsufficientTimeForOperation:
                    return "Insufficient time for operation";
                case AdditionalSenseInformation.CommandsClearedByAnotherInitiator:
                    return "Commands cleared by another initiator";
                case AdditionalSenseInformation.MediumDestinationElementFull:
                    return "Medium destination element full";
                case AdditionalSenseInformation.MediumSourceElementEmpty:
                    return "Medium source element empty";
                case AdditionalSenseInformation.EndOfMediumReached:
                    return "End of medium reached";
                case AdditionalSenseInformation.MediumMagazineNotAccessible:
                    return "Medium magazine not accessible";
                case AdditionalSenseInformation.MediumMagazineRemoved:
                    return "Medium magazine removed";
                case AdditionalSenseInformation.MediumMagazineInserted:
                    return "Medium magazine inserted";
                case AdditionalSenseInformation.MediumMagazineLocked:
                    return "Medium magazine locked";
                case AdditionalSenseInformation.MediumMagazineUnlocked:
                    return "Medium magazine unlocked";
                case AdditionalSenseInformation.TargetOperatingConditionsHaveChanged:
                    return "Target operating conditions have changed";
                case AdditionalSenseInformation.MicrocodeHasBeenChanged:
                    return "Microcode has been changed";
                case AdditionalSenseInformation.ChangedOperatingDefinition:
                    return "Changed operating definition";
                case AdditionalSenseInformation.InquiryDataHasChanged:
                    return "Inquiry data has changed";
                case AdditionalSenseInformation.OperatorRequestOrStateChangeInput:
                    return "Operator request or state change input";
                case AdditionalSenseInformation.OperatorMediumRemovalRequest:
                    return "Operator medium removal request";
                case AdditionalSenseInformation.OperatorSelectedWriteProtect:
                    return "Operator selected write protect";
                case AdditionalSenseInformation.OperatorSelectedWritePermit:
                    return "Operator selected write permit";
                case AdditionalSenseInformation.LogException:
                    return "Log exception";
                case AdditionalSenseInformation.ThresholdConditionMet:
                    return "Threshold condition met";
                case AdditionalSenseInformation.LogCounterAtMaximum:
                    return "Log counter at maximum";
                case AdditionalSenseInformation.LogListCodesExhausted:
                    return "Log list codes exhausted";
                case AdditionalSenseInformation.LowPowerConditionOn:
                    return "Low power condition on";
                case AdditionalSenseInformation.IdleConditionActivatedByTimer:
                    return "Idle condition activated by timer";
                case AdditionalSenseInformation.StandbyConditionActivatedByTimer:
                    return "Standby condition activated by timer";
                case AdditionalSenseInformation.IdleConditionActivatedByCommand:
                    return "Idle condition activated by command";
                case AdditionalSenseInformation.StandbyConditionActivatedByCommand:
                    return "Standby condition activated by command";
                case AdditionalSenseInformation.WriteProtected:
                    return "Write protected";
                case AdditionalSenseInformation.HardwareWriteProtected:
                    return "Hardware write protected";
                case AdditionalSenseInformation.LogicalUnitSoftwareWriteProtected:
                    return "Logical unit software write protected";
                case AdditionalSenseInformation.AssociatedWriteProtect:
                    return "Associated write protect";
                case AdditionalSenseInformation.PersistentWriteProtect:
                    return "Persistent write protect";
                case AdditionalSenseInformation.PermanentWriteProtect:
                    return "Permanent write protect";
                case AdditionalSenseInformation.ConditionalWriteProtect:
                    return "Conditional write protect";
                case AdditionalSenseInformation.MiscompareDuringVerifyOperation:
                    return "Miscompare during verify operation";
                case AdditionalSenseInformation.IOProcessTerminated:
                    return "I/O process terminated";
                case AdditionalSenseInformation.ReadErrorLossOfStreaming:
                    return "Read error - loss of streaming";
                case AdditionalSenseInformation.SelectOrReselectFailure:
                    return "Select or reselect failure";
                case AdditionalSenseInformation.InitiatorDetectedErrorMessageReceived:
                    return "Initiator detected error message received";
                case AdditionalSenseInformation.InvalidMessageError:
                    return "Invalid message error";
                case AdditionalSenseInformation.OverlappedCommandsAttempted:
                    return "Overlapped commands attempted";
                default:
                    return null;
            }
        }

#if OLD_MESSAGES
		public static string GetMessageOld(byte senseKey, byte additionalSenseCode, byte additionalSenseCodeQualifier)
		{
			string result = null;
			switch (senseKey)
			{
				case 0x0:
					if (additionalSenseCode == 0x00 & additionalSenseCodeQualifier == 0x00) { result = "No additional sense information"; }
					else if (additionalSenseCode == 0x04 & additionalSenseCodeQualifier == 0x04) { result = "Logical unit not ready, format in progress (sense key specific bytes contains a progress indication)"; }

					break;
				case 0x1:
					if (additionalSenseCode == 0x0B)
					{
						if (additionalSenseCodeQualifier == 0x00) { result = "Warning"; }
						else if (additionalSenseCodeQualifier == 0x01) { result = "Warning - specified temperature exceeded"; }
						else if (additionalSenseCodeQualifier == 0x02) { result = "Warning - enclosure degraded"; }
						else if (additionalSenseCodeQualifier == 0x03) { result = "Warning - background self-test failed"; }
						else if (additionalSenseCodeQualifier == 0x04) { result = "Warning - background pre-scan detected medium error"; }
						else if (additionalSenseCodeQualifier == 0x05) { result = "Warning - background medium scan detected medium error"; }

					}
					else if (additionalSenseCode == 0x0C & additionalSenseCodeQualifier == 0x01) { result = "Write error - recovered with auto-reallocation"; }
					else if (additionalSenseCode == 0x17)
					{
						if (additionalSenseCodeQualifier == 0x00) { result = "Recovered data with no error correction applied"; }
						else if (additionalSenseCodeQualifier == 0x01) { result = "Recovered data with retries"; }
						else if (additionalSenseCodeQualifier == 0x02) { result = "Recovered data with positive head offset"; }
						else if (additionalSenseCodeQualifier == 0x03) { result = "Recovered data with negative head offset"; }
						else if (additionalSenseCodeQualifier == 0x04) { result = "Recovered data with retries and/or circ applied"; }
						else if (additionalSenseCodeQualifier == 0x05) { result = "Recovered data using previous sector id"; }
						else if (additionalSenseCodeQualifier == 0x07) { result = "Recovered data without ECC - recommend reassignment"; }
						else if (additionalSenseCodeQualifier == 0x08) { result = "Recovered data without ECC - recommend rewrite"; }
						else if (additionalSenseCodeQualifier == 0x09) { result = "Recovered data without ECC - data rewritten"; }

					}
					else if (additionalSenseCode == 0x18)
					{
						if (additionalSenseCodeQualifier == 0x00) { result = "Recovered data with error correction applied"; }
						else if (additionalSenseCodeQualifier == 0x01) { result = "Recovered data with error correction & retries applied"; }
						else if (additionalSenseCodeQualifier == 0x02) { result = "Recovered data - data auto-reallocated"; }
						else if (additionalSenseCodeQualifier == 0x03) { result = "Recovered data with circ"; }
						else if (additionalSenseCodeQualifier == 0x04) { result = "Recovered data with L-EC"; }
						else if (additionalSenseCodeQualifier == 0x05) { result = "Recovered data - recommend reassignment"; }
						else if (additionalSenseCodeQualifier == 0x06) { result = "Recovered data - recommend rewrite"; }
						else if (additionalSenseCodeQualifier == 0x08) { result = "Recovered data with linking"; }

					}
					else if (additionalSenseCode == 0x37 & additionalSenseCodeQualifier == 0x00) { result = "Rounded parameter"; }
					else if (additionalSenseCode == 0x5D)
					{
						if (additionalSenseCodeQualifier == 0x00) { result = "Failure prediction threshold exceeded"; }
						else if (additionalSenseCodeQualifier == 0x01) { result = "Media failure prediction threshold exceeded"; }
						else if (additionalSenseCodeQualifier == 0x01) { result = "Failure prediction threshold exceeded - predicted media failure"; }
						else if (additionalSenseCodeQualifier == 0x02) { result = "Logical unit failure prediction threshold exceeded"; }
						else if (additionalSenseCodeQualifier == 0x03) { result = "Failure prediction threshold exceeded - predicted spare area exhaustion"; }
						else if (additionalSenseCodeQualifier == 0x03) { result = "Spare area exhaustion failure prediction threshold exceeded"; }
						else if (additionalSenseCodeQualifier == 0x03) { result = "Failure prediction threshold exceeded - predicted spare area exhaustion"; }
						else if (additionalSenseCodeQualifier == 0xFF) { result = "Failure prediction threshold exceeded (false)"; }

					}
					else if (additionalSenseCode == 0x73)
					{
						if (additionalSenseCodeQualifier == 0x01) { result = "Power calibration area almost full"; }
						else if (additionalSenseCodeQualifier == 0x06) { result = "RMA/PMA is almost full"; }

					}

					break;
				case 0x2:
					if (additionalSenseCode == 0x04)
					{
						if (additionalSenseCodeQualifier == 0x00) { result = "Logical unit not ready, cause not reportable"; }
						else if (additionalSenseCodeQualifier == 0x01) { result = "Logical unit is in process of becoming ready"; }
						else if (additionalSenseCodeQualifier == 0x02) { result = "Logical unit not ready, initializing cmd. required"; }
						else if (additionalSenseCodeQualifier == 0x03) { result = "Logical unit not ready, manual intervention required"; }
						else if (additionalSenseCodeQualifier == 0x04) { result = "Logical unit not ready, format in progress"; }
						else if (additionalSenseCodeQualifier == 0x04) { result = "Logical unit not ready, format in progress (sense key specific bytes contains a progress indication)"; }
						else if (additionalSenseCodeQualifier == 0x07) { result = "Logical unit not ready, operation in progress"; }
						else if (additionalSenseCodeQualifier == 0x08) { result = "Logical unit not ready, long write in progress"; }
						else if (additionalSenseCodeQualifier == 0x09) { result = "Logical unit not ready, self-test in progress"; }
					}
					else if (additionalSenseCode == 0x0C)
					{
						if (additionalSenseCodeQualifier == 0x07) { result = "Write error recovery needed"; }
						else if (additionalSenseCodeQualifier == 0x07) { result = "Write error - recovery needed"; }
						else if (additionalSenseCodeQualifier == 0x0F) { result = "Defects in error window"; }
					}
					else if (additionalSenseCode == 0x30)
					{
						if (additionalSenseCodeQualifier == 0x00) { result = "Incompatible medium installed"; }
						else if (additionalSenseCodeQualifier == 0x01) { result = "Cannot read medium - unknown format"; }
						else if (additionalSenseCodeQualifier == 0x02) { result = "Cannot read medium - incompatible format"; }
						else if (additionalSenseCodeQualifier == 0x03) { result = "Cleaning cartridge installed"; }
						else if (additionalSenseCodeQualifier == 0x04) { result = "Cannot write medium - unknown format"; }
						else if (additionalSenseCodeQualifier == 0x05) { result = "Cannot write medium - incompatible format"; }
						else if (additionalSenseCodeQualifier == 0x06) { result = "Cannot format medium - incompatible medium"; }
						else if (additionalSenseCodeQualifier == 0x07) { result = "Cleaning failure"; }
						else if (additionalSenseCodeQualifier == 0x11) { result = "Cannot write medium - unsupported medium version"; }
					}
					else if (additionalSenseCode == 0x3A)
					{
						if (additionalSenseCodeQualifier == 0x00) { result = "Medium not present"; }
						else if (additionalSenseCodeQualifier == 0x01) { result = "Medium not present - tray closed"; }
						else if (additionalSenseCodeQualifier == 0x02) { result = "Medium not present - tray open"; }
						else if (additionalSenseCodeQualifier == 0x03) { result = "Medium not present - loadable"; }
					}
					else if (additionalSenseCode == 0x3E & additionalSenseCodeQualifier == 0x00) { result = "Logical unit has not self-configured yet"; }
					break;
				case 0x3:
					if (additionalSenseCode == 0x02 & additionalSenseCodeQualifier == 0x00) { result = "No seek complete"; }
					else if (additionalSenseCode == 0x06 & additionalSenseCodeQualifier == 0x00) { result = "No reference position found"; }

					else if (additionalSenseCode == 0x0C)
					{
						if (additionalSenseCodeQualifier == 0x00) { result = "Write error"; }
						else if (additionalSenseCodeQualifier == 0x02) { result = "Write error - auto-reallocation failed"; }
						else if (additionalSenseCodeQualifier == 0x03) { result = "Write error - recommend reassignment"; }
						else if (additionalSenseCodeQualifier == 0x07) { result = "Write error - recovery needed"; }
						else if (additionalSenseCodeQualifier == 0x08) { result = "Write error - recovery failed"; }
						else if (additionalSenseCodeQualifier == 0x09) { result = "Write error - loss of streaming"; }
						else if (additionalSenseCodeQualifier == 0x0A) { result = "Write error - padding blocks added"; }
					}
					else if (additionalSenseCode == 0x11)
					{
						if (additionalSenseCodeQualifier == 0x00) { result = "Unrecovered read error"; }
						else if (additionalSenseCodeQualifier == 0x01) { result = "Read retries exhausted"; }
						else if (additionalSenseCodeQualifier == 0x02) { result = "Error too long to correct"; }
						else if (additionalSenseCodeQualifier == 0x05) { result = "L-EC uncorrectable error"; }
						else if (additionalSenseCodeQualifier == 0x06) { result = "Circ unrecovered error"; }
						else if (additionalSenseCodeQualifier == 0x0F) { result = "Error reading UPC/EAN number"; }
						else if (additionalSenseCodeQualifier == 0x10) { result = "Error reading ISRC number"; }
					}
					else if (additionalSenseCode == 0x15)
					{
						if (additionalSenseCodeQualifier == 0x00) { result = "Random positioning error"; }
						else if (additionalSenseCodeQualifier == 0x01) { result = "Mechanical positioning error"; }
						else if (additionalSenseCodeQualifier == 0x02) { result = "Positioning error detected by read of medium"; }
					}
					else if (additionalSenseCode == 0x31)
					{
						if (additionalSenseCodeQualifier == 0x00) { result = "Medium format corrupted"; }
						else if (additionalSenseCodeQualifier == 0x01) { result = "Format command failed"; }
						else if (additionalSenseCodeQualifier == 0x02) { result = "Zoned formatting failed due to spare linking"; }
					}
					else if (additionalSenseCode == 0x32 & additionalSenseCodeQualifier == 0x00) { result = "No defect spare location available"; }
					else if (additionalSenseCode == 0x51)
					{
						if (additionalSenseCodeQualifier == 0x00) { result = "Erase failure"; }
						else if (additionalSenseCodeQualifier == 0x01) { result = "Erase failure - incomplete erase operation detected"; }
					}
					else if (additionalSenseCode == 0x57 & additionalSenseCodeQualifier == 0x00) { result = "Unable to recover table-of-contents"; }
					else if (additionalSenseCode == 0x5D)
					{
						if (additionalSenseCodeQualifier == 0x00) { result = "Failure prediction threshold exceeded"; }
						else if (additionalSenseCodeQualifier == 0x01) { result = "Media failure prediction threshold exceeded"; }
						else if (additionalSenseCodeQualifier == 0x02) { result = "Logical unit failure prediction threshold exceeded"; }
						else if (additionalSenseCodeQualifier == 0x03) { result = "Failure prediction threshold exceeded - predicted spare area exhaustion"; }
					}
					else if (additionalSenseCode == 0x72)
					{
						if (additionalSenseCodeQualifier == 0x00) { result = "Session fixation error"; }
						else if (additionalSenseCodeQualifier == 0x01) { result = "Session fixation error writing lead-in"; }
						else if (additionalSenseCodeQualifier == 0x02) { result = "Session fixation error writing lead-out"; }
					}
					else if (additionalSenseCode == 0x73)
					{
						if (additionalSenseCodeQualifier == 0x00) { result = "Cd control error"; }
						else if (additionalSenseCodeQualifier == 0x02) { result = "Power calibration area is full"; }
						else if (additionalSenseCodeQualifier == 0x03) { result = "Power calibration area error"; }
						else if (additionalSenseCodeQualifier == 0x04) { result = "Program memory area update failure"; }
						else if (additionalSenseCodeQualifier == 0x05) { result = "Program memory area is full"; }
						else if (additionalSenseCodeQualifier == 0x10) { result = "Current power calibration area is almost full"; }
						else if (additionalSenseCodeQualifier == 0x11) { result = "Current power calibration area is full"; }
					}
					break;
				case 0x4:
					if (additionalSenseCode == 0x00 & additionalSenseCodeQualifier == 0x17) { result = "Cleaning requested"; }

					else if (additionalSenseCode == 0x05 & additionalSenseCodeQualifier == 0x00) { result = "Logical unit does not respond to selection"; }

					else if (additionalSenseCode == 0x08 & additionalSenseCodeQualifier == 0x00) { result = "Logical unit communication failure"; }
					else if (additionalSenseCode == 0x08 & additionalSenseCodeQualifier == 0x01) { result = "Logical unit communication timeout"; }
					else if (additionalSenseCode == 0x08 & additionalSenseCodeQualifier == 0x02) { result = "Logical unit communication parity error"; }
					else if (additionalSenseCode == 0x08 & additionalSenseCodeQualifier == 0x03) { result = "Logical unit communication CRC error (Ultra-DMA/32)"; }

					else if (additionalSenseCode == 0x09 & additionalSenseCodeQualifier == 0x00) { result = "Track following error"; }
					else if (additionalSenseCode == 0x09 & additionalSenseCodeQualifier == 0x01) { result = "Tracking servo failure"; }
					else if (additionalSenseCode == 0x09 & additionalSenseCodeQualifier == 0x02) { result = "Focus servo failure"; }
					else if (additionalSenseCode == 0x09 & additionalSenseCodeQualifier == 0x03) { result = "Spindle servo failure"; }
					else if (additionalSenseCode == 0x09 & additionalSenseCodeQualifier == 0x04) { result = "Head select fault"; }

					else if (additionalSenseCode == 0x15 & additionalSenseCodeQualifier == 0x00) { result = "Random positioning error"; }
					else if (additionalSenseCode == 0x15 & additionalSenseCodeQualifier == 0x01) { result = "Mechanical positioning error"; }

					else if (additionalSenseCode == 0x1B & additionalSenseCodeQualifier == 0x00) { result = "Synchronous data transfer error"; }
					else if (additionalSenseCode == 0x3B & additionalSenseCodeQualifier == 0x16) { result = "Mechanical positioning or changer error"; }

					else if (additionalSenseCode == 0x3E & additionalSenseCodeQualifier == 0x01) { result = "Logical unit failure"; }
					else if (additionalSenseCode == 0x3E & additionalSenseCodeQualifier == 0x02) { result = "Timeout on logical unit"; }

					else if (additionalSenseCode == 0x40) { result = string.Format("Diagnostic failure on component {0} (0x80-0xFF)", additionalSenseCodeQualifier); }
					else if (additionalSenseCode == 0x44 & additionalSenseCodeQualifier == 0x00) { result = "Internal target failure"; }
					else if (additionalSenseCode == 0x46 & additionalSenseCodeQualifier == 0x00) { result = "Unsuccessful soft reset"; }
					else if (additionalSenseCode == 0x47 & additionalSenseCodeQualifier == 0x00) { result = "Scsi parity error"; }
					else if (additionalSenseCode == 0x4A & additionalSenseCodeQualifier == 0x00) { result = "Command phase error"; }
					else if (additionalSenseCode == 0x4B & additionalSenseCodeQualifier == 0x00) { result = "Data phase error"; }
					else if (additionalSenseCode == 0x4C & additionalSenseCodeQualifier == 0x00) { result = "Logical unit failed self-configuration"; }
					else if (additionalSenseCode == 0x53 & additionalSenseCodeQualifier == 0x00) { result = "Media load or eject failed"; }
					else if (additionalSenseCode == 0x65 & additionalSenseCodeQualifier == 0x00) { result = "Voltage fault"; }

					break;
				case 0x5:
					if (additionalSenseCode == 0x00 & additionalSenseCodeQualifier == 0x16) { result = "Operation in progress"; }
					else if (additionalSenseCode == 0x07 & additionalSenseCodeQualifier == 0x00) { result = "Multiple peripheral devices selected"; }
					else if (additionalSenseCode == 0x1A & additionalSenseCodeQualifier == 0x00) { result = "Parameter list length error"; }
					else if (additionalSenseCode == 0x20 & additionalSenseCodeQualifier == 0x00) { result = "Invalid command operation code"; }

					else if (additionalSenseCode == 0x21 & additionalSenseCodeQualifier == 0x00) { result = "Logical block address out of range"; }
					else if (additionalSenseCode == 0x21 & additionalSenseCodeQualifier == 0x01) { result = "Invalid element address"; }
					else if (additionalSenseCode == 0x21 & additionalSenseCodeQualifier == 0x02) { result = "Invalid address for write"; }
					else if (additionalSenseCode == 0x21 & additionalSenseCodeQualifier == 0x03) { result = "Invalid write crossing layer jump"; }

					else if (additionalSenseCode == 0x22 & additionalSenseCodeQualifier == 0x00) { result = "Illegal function"; }
					else if (additionalSenseCode == 0x22 & additionalSenseCodeQualifier == 0x00) { result = "Invalid function"; }

					else if (additionalSenseCode == 0x24 & additionalSenseCodeQualifier == 0x00) { result = "Invalid field in CDB"; }
					else if (additionalSenseCode == 0x25 & additionalSenseCodeQualifier == 0x00) { result = "Logical unit not supported"; }

					else if (additionalSenseCode == 0x26 & additionalSenseCodeQualifier == 0x00) { result = "Invalid field in parameter list"; }
					else if (additionalSenseCode == 0x26 & additionalSenseCodeQualifier == 0x01) { result = "Parameter not supported"; }
					else if (additionalSenseCode == 0x26 & additionalSenseCodeQualifier == 0x02) { result = "Parameter value invalid"; }
					else if (additionalSenseCode == 0x26 & additionalSenseCodeQualifier == 0x03) { result = "Threshold parameters not supported"; }
					else if (additionalSenseCode == 0x26 & additionalSenseCodeQualifier == 0x04) { result = "Invalid release of persistent reservation"; }

					else if (additionalSenseCode == 0x2B & additionalSenseCodeQualifier == 0x00) { result = "Copy cannot execute since initiator cannot disconnect"; }

					else if (additionalSenseCode == 0x2C & additionalSenseCodeQualifier == 0x00) { result = "Command sequence error"; }
					else if (additionalSenseCode == 0x2C & additionalSenseCodeQualifier == 0x03) { result = "Current program area is not empty"; }
					else if (additionalSenseCode == 0x2C & additionalSenseCodeQualifier == 0x04) { result = "Current program area is empty"; }

					else if (additionalSenseCode == 0x30 & additionalSenseCodeQualifier == 0x00) { result = "Incompatible medium installed"; }
					else if (additionalSenseCode == 0x30 & additionalSenseCodeQualifier == 0x01) { result = "Cannot read medium - unknown format"; }
					else if (additionalSenseCode == 0x30 & additionalSenseCodeQualifier == 0x02) { result = "Cannot read medium - incompatible format"; }
					else if (additionalSenseCode == 0x30 & additionalSenseCodeQualifier == 0x03) { result = "Cleaning cartridge installed"; }
					else if (additionalSenseCode == 0x30 & additionalSenseCodeQualifier == 0x04) { result = "Cannot write medium - unknown format"; }
					else if (additionalSenseCode == 0x30 & additionalSenseCodeQualifier == 0x05) { result = "Cannot write medium - incompatible format"; }
					else if (additionalSenseCode == 0x30 & additionalSenseCodeQualifier == 0x06) { result = "Cannot format medium - incompatible medium"; }
					else if (additionalSenseCode == 0x30 & additionalSenseCodeQualifier == 0x07) { result = "Cleaning failure"; }
					else if (additionalSenseCode == 0x30 & additionalSenseCodeQualifier == 0x08) { result = "Cannot write - application code mismatch"; }
					else if (additionalSenseCode == 0x30 & additionalSenseCodeQualifier == 0x09) { result = "Current session not fixated for append"; }
					else if (additionalSenseCode == 0x30 & additionalSenseCodeQualifier == 0x10) { result = "Medium not formatted"; }
					else if (additionalSenseCode == 0x30 & additionalSenseCodeQualifier == 0x11) { result = "Cannot write medium - unsupported medium version"; }

					else if (additionalSenseCode == 0x39 & additionalSenseCodeQualifier == 0x00) { result = "Saving parameters not supported"; }
					else if (additionalSenseCode == 0x3D & additionalSenseCodeQualifier == 0x00) { result = "Invalid bits in identify message"; }
					else if (additionalSenseCode == 0x43 & additionalSenseCodeQualifier == 0x00) { result = "Message error"; }
					else if (additionalSenseCode == 0x53 & additionalSenseCodeQualifier == 0x02) { result = "Medium removal prevented"; }
					else if (additionalSenseCode == 0x55 & additionalSenseCodeQualifier == 0x00) { result = "System resource failure"; }

					else if (additionalSenseCode == 0x63 & additionalSenseCodeQualifier == 0x00) { result = "End of user area encountered on this track"; }
					else if (additionalSenseCode == 0x63 & additionalSenseCodeQualifier == 0x01) { result = "Packet does not fit in available space"; }

					else if (additionalSenseCode == 0x64 & additionalSenseCodeQualifier == 0x00) { result = "Illegal mode for this track"; }
					else if (additionalSenseCode == 0x64 & additionalSenseCodeQualifier == 0x01) { result = "Invalid packet size"; }

					else if (additionalSenseCode == 0x6F & additionalSenseCodeQualifier == 0x00) { result = "Copy protection key exchange failure - authentication failure"; }
					else if (additionalSenseCode == 0x6F & additionalSenseCodeQualifier == 0x01) { result = "Copy protection key exchange failure - key not present"; }
					else if (additionalSenseCode == 0x6F & additionalSenseCodeQualifier == 0x02) { result = "Copy protection key exchange failure -key not established"; }
					else if (additionalSenseCode == 0x6F & additionalSenseCodeQualifier == 0x03) { result = "Read of scrambled sector without authentication"; }
					else if (additionalSenseCode == 0x6F & additionalSenseCodeQualifier == 0x04) { result = "Media region code is mismatched to logical unit region"; }
					else if (additionalSenseCode == 0x6F & additionalSenseCodeQualifier == 0x05) { result = "Logical unit region must be permanent/region reset count error"; }
					else if (additionalSenseCode == 0x6F & additionalSenseCodeQualifier == 0x06) { result = "Insufficient block count for binding nonce recording"; }
					else if (additionalSenseCode == 0x6F & additionalSenseCodeQualifier == 0x07) { result = "Conflict in binding nonce recording"; }

					else if (additionalSenseCode == 0x72 & additionalSenseCodeQualifier == 0x03) { result = "Session fixation error - incomplete track in session"; }
					else if (additionalSenseCode == 0x72 & additionalSenseCodeQualifier == 0x04) { result = "Empty or partially written reserved track"; }
					else if (additionalSenseCode == 0x72 & additionalSenseCodeQualifier == 0x05) { result = "No more track reservations allowed"; }
					else if (additionalSenseCode == 0x72 & additionalSenseCodeQualifier == 0x06) { result = "RMZ extension is not allowed"; }
					else if (additionalSenseCode == 0x72 & additionalSenseCodeQualifier == 0x07) { result = "No more test zone extensions are allowed"; }

					else if (additionalSenseCode == 0x73 & additionalSenseCodeQualifier == 0x17) { result = "RDZ is full"; }

					break;
				case 0x6:
					if (additionalSenseCode == 0x0A & additionalSenseCodeQualifier == 0x00) { result = "Error log overflow"; }

					else if (additionalSenseCode == 0x28 & additionalSenseCodeQualifier == 0x00) { result = "Not ready to ready change, medium may have changed"; }
					else if (additionalSenseCode == 0x28 & additionalSenseCodeQualifier == 0x01) { result = "Import or export element accessed"; }
					else if (additionalSenseCode == 0x28 & additionalSenseCodeQualifier == 0x02) { result = "Format-layer may have changed"; }

					else if (additionalSenseCode == 0x29 & additionalSenseCodeQualifier == 0x00) { result = "Power on, reset, or bus device reset occurred"; }
					else if (additionalSenseCode == 0x29 & additionalSenseCodeQualifier == 0x01) { result = "Power on occurred"; }
					else if (additionalSenseCode == 0x29 & additionalSenseCodeQualifier == 0x02) { result = "Bus reset occurred"; }
					else if (additionalSenseCode == 0x29 & additionalSenseCodeQualifier == 0x03) { result = "Bus device reset function occurred"; }
					else if (additionalSenseCode == 0x29 & additionalSenseCodeQualifier == 0x04) { result = "Device internal reset"; }

					else if (additionalSenseCode == 0x2A & additionalSenseCodeQualifier == 0x00) { result = "Parameters changed"; }
					else if (additionalSenseCode == 0x2A & additionalSenseCodeQualifier == 0x01) { result = "Mode parameters changed"; }
					else if (additionalSenseCode == 0x2A & additionalSenseCodeQualifier == 0x02) { result = "Log parameters changed"; }
					else if (additionalSenseCode == 0x2A & additionalSenseCodeQualifier == 0x03) { result = "Reservations preempted"; }

					else if (additionalSenseCode == 0x2E & additionalSenseCodeQualifier == 0x00) { result = "Insufficient time for operation"; }

					else if (additionalSenseCode == 0x2F & additionalSenseCodeQualifier == 0x00) { result = "Commands cleared by another initiator"; }

					else if (additionalSenseCode == 0x3B & additionalSenseCodeQualifier == 0x0D) { result = "Medium destination element full"; }
					else if (additionalSenseCode == 0x3B & additionalSenseCodeQualifier == 0x0E) { result = "Medium source element empty"; }
					else if (additionalSenseCode == 0x3B & additionalSenseCodeQualifier == 0x0F) { result = "End of medium reached"; }
					else if (additionalSenseCode == 0x3B & additionalSenseCodeQualifier == 0x11) { result = "Medium magazine not accessible"; }
					else if (additionalSenseCode == 0x3B & additionalSenseCodeQualifier == 0x12) { result = "Medium magazine removed"; }
					else if (additionalSenseCode == 0x3B & additionalSenseCodeQualifier == 0x13) { result = "Medium magazine inserted"; }
					else if (additionalSenseCode == 0x3B & additionalSenseCodeQualifier == 0x14) { result = "Medium magazine locked"; }
					else if (additionalSenseCode == 0x3B & additionalSenseCodeQualifier == 0x15) { result = "Medium magazine unlocked"; }

					else if (additionalSenseCode == 0x3F & additionalSenseCodeQualifier == 0x00) { result = "Target operating conditions have changed"; }
					else if (additionalSenseCode == 0x3F & additionalSenseCodeQualifier == 0x01) { result = "Microcode has been changed"; }
					else if (additionalSenseCode == 0x3F & additionalSenseCodeQualifier == 0x02) { result = "Changed operating definition"; }
					else if (additionalSenseCode == 0x3F & additionalSenseCodeQualifier == 0x03) { result = "Inquiry data has changed"; }

					else if (additionalSenseCode == 0x5A & additionalSenseCodeQualifier == 0x00) { result = "Operator request or state change input"; }
					else if (additionalSenseCode == 0x5A & additionalSenseCodeQualifier == 0x01) { result = "Operator medium removal request"; }
					else if (additionalSenseCode == 0x5A & additionalSenseCodeQualifier == 0x02) { result = "Operator selected write protect"; }
					else if (additionalSenseCode == 0x5A & additionalSenseCodeQualifier == 0x03) { result = "Operator selected write permit"; }

					else if (additionalSenseCode == 0x5B & additionalSenseCodeQualifier == 0x00) { result = "Log exception"; }
					else if (additionalSenseCode == 0x5B & additionalSenseCodeQualifier == 0x01) { result = "Threshold condition met"; }
					else if (additionalSenseCode == 0x5B & additionalSenseCodeQualifier == 0x02) { result = "Log counter at maximum"; }
					else if (additionalSenseCode == 0x5B & additionalSenseCodeQualifier == 0x03) { result = "Log list codes exhausted"; }

					else if (additionalSenseCode == 0x5E & additionalSenseCodeQualifier == 0x00) { result = "Low power condition on"; }
					else if (additionalSenseCode == 0x5E & additionalSenseCodeQualifier == 0x01) { result = "Idle condition activated by timer"; }
					else if (additionalSenseCode == 0x5E & additionalSenseCodeQualifier == 0x02) { result = "Standby condition activated by timer"; }
					else if (additionalSenseCode == 0x5E & additionalSenseCodeQualifier == 0x03) { result = "Idle condition activated by command"; }
					else if (additionalSenseCode == 0x5E & additionalSenseCodeQualifier == 0x04) { result = "Standby condition activated by command"; }


					break;
				case 0x7:
					if (additionalSenseCode == 0x27)
					{
						if (additionalSenseCodeQualifier == 0x00) { result = "Write protected"; }
						else if (additionalSenseCodeQualifier == 0x01) { result = "Hardware write protected"; }
						else if (additionalSenseCodeQualifier == 0x02) { result = "Logical unit software write protected"; }
						else if (additionalSenseCodeQualifier == 0x03) { result = "Associated write protect"; }
						else if (additionalSenseCodeQualifier == 0x04) { result = "Persistent write protect"; }
						else if (additionalSenseCodeQualifier == 0x05) { result = "Permanent write protect"; }
						else if (additionalSenseCodeQualifier == 0x06) { result = "Conditional write protect"; }
					}
					break;
				case 0xA:
					if (additionalSenseCode == 0x1D & additionalSenseCodeQualifier == 0x00) { result = "Miscompare during verify operation"; }
					break;
				case 0xB:
					if (additionalSenseCode == 0x00 & additionalSenseCodeQualifier == 0x06) { result = "I/O process terminated"; }
					else if (additionalSenseCode == 0x11 & additionalSenseCodeQualifier == 0x11) { result = "Read error - loss of streaming"; }
					else if (additionalSenseCode == 0x45 & additionalSenseCodeQualifier == 0x00) { result = "Select or reselect failure"; }
					else if (additionalSenseCode == 0x48 & additionalSenseCodeQualifier == 0x00) { result = "Initiator detected error message received"; }
					else if (additionalSenseCode == 0x49 & additionalSenseCodeQualifier == 0x00) { result = "Invalid message error"; }
					else if (additionalSenseCode == 0x4D) { result = string.Format("Tagged overlapped commands ({0} = queue tag)", additionalSenseCodeQualifier); }
					else if (additionalSenseCode == 0x4E & additionalSenseCodeQualifier == 0x00) { result = "Overlapped commands attempted"; }

					break;
			}
			if (result == null)
			{
				result = string.Format("Unknown error: SK = {0}, ASC = {1}, ASCQ = {2}", senseKey, additionalSenseCode, additionalSenseCodeQualifier);
			}
			return result;
		}
#endif

        public static Exception CreateException(SenseData senseData, bool forceScsiException)
        {
            Exception ex = new ScsiException(senseData);
            if (!forceScsiException)
            {
                switch (senseData.SenseKey)
                {
                    case SenseKey.RecoveredError:
                        ex =
                            new IOException(
                                "The command completed successfully, with some recovery action performed by the device server." +
                                Environment.NewLine + Environment.NewLine + "Details: " +
                                GetMessage(senseData.SenseKey, senseData.AdditionalSenseCodeAndQualifier), ex);
                        break;
                    case SenseKey.NotReady:
                        ex =
                            new IOException(
                                "The logical unit is not accessible. Operator intervention may be required to correct this condition." +
                                Environment.NewLine + Environment.NewLine + "Details: " +
                                GetMessage(senseData.SenseKey, senseData.AdditionalSenseCodeAndQualifier), ex);
                        break;
                    case SenseKey.MediumError:
                        ex =
                            new IOException(
                                "the command terminated with a non-recovered error condition that may have been caused by a flaw in the medium or an error in the recorded data. This sense key may also be returned if the device server is unable to distinguish between a flaw in the medium and a specific hardware failure." +
                                Environment.NewLine + Environment.NewLine + "Details: " +
                                GetMessage(senseData.SenseKey, senseData.AdditionalSenseCodeAndQualifier), ex);
                        break;
                    case SenseKey.HardwareError:
                        ex =
                            new IOException(
                                "The device server detected a non-recoverable hardware failure (e.g., controller failure, device failure, or parity error) while performing the command or during a self test." +
                                Environment.NewLine + Environment.NewLine + "Details: " +
                                GetMessage(senseData.SenseKey, senseData.AdditionalSenseCodeAndQualifier), ex);
                        break;
                    case SenseKey.IllegalRequest:
                        ex =
                            new InvalidOperationException(
                                "An illegal operation was requested." + Environment.NewLine + Environment.NewLine +
                                "Details: " + GetMessage(senseData.SenseKey, senseData.AdditionalSenseCodeAndQualifier),
                                ex);
                        break;
                    case SenseKey.UnitAttention:
                        ex =
                            new IOException(
                                "A unit attention condition has been established (e.g., the removable medium may have been changed, a logical unit reset occurred)." +
                                Environment.NewLine + Environment.NewLine + "Details: " +
                                GetMessage(senseData.SenseKey, senseData.AdditionalSenseCodeAndQualifier), ex);
                        break;
                    case SenseKey.DataProtect:
                        ex =
                            new UnauthorizedAccessException(
                                "That a command that reads or writes the medium was attempted on a block that is protected. The read or write operation is not performed." +
                                Environment.NewLine + Environment.NewLine + "Details: " +
                                GetMessage(senseData.SenseKey, senseData.AdditionalSenseCodeAndQualifier), ex);
                        break;
                    case SenseKey.BlankCheck:
                        ex =
                            new IOException(
                                "A write-once device or a sequential-access device encountered blank medium or format-defined end-of-data indication while reading or that a write-once device encountered a non-blank medium while writing." +
                                Environment.NewLine + Environment.NewLine + "Details: " +
                                GetMessage(senseData.SenseKey, senseData.AdditionalSenseCodeAndQualifier), ex);
                        break;
                    case SenseKey.CopyAborted:
                        ex =
                            new IOException(
                                "An EXTENDED COPY command was aborted due to an error condition on the source device, the destination device, or both." +
                                Environment.NewLine + Environment.NewLine + "Details: " +
                                GetMessage(senseData.SenseKey, senseData.AdditionalSenseCodeAndQualifier), ex);
                        break;
                    case SenseKey.AbortedCommand:
                        ex =
                            new OperationCanceledException(
                                "The device server aborted the command. The application client may be able to recover by trying the command again." +
                                Environment.NewLine + Environment.NewLine + "Details: " +
                                GetMessage(senseData.SenseKey, senseData.AdditionalSenseCodeAndQualifier), ex);
                        break;
                    case SenseKey.VolumeOverflow:
                        ex =
                            new EndOfStreamException(
                                "A buffered SCSI device has reached the end-of-partition and data may remain in the buffer that has not been written to the medium. One or more RECOVER BUFFERED DATA command(s) may be issued to read the unwritten data from the buffer." +
                                Environment.NewLine + Environment.NewLine + "Details: " +
                                GetMessage(senseData.SenseKey, senseData.AdditionalSenseCodeAndQualifier), ex);
                        break;
                    case SenseKey.Miscompare:
                        ex =
                            new InvalidDataException(
                                "The source data did not match the data read from the medium." + Environment.NewLine +
                                Environment.NewLine + "Details: " +
                                GetMessage(senseData.SenseKey, senseData.AdditionalSenseCodeAndQualifier), ex);
                        break;
                }
            }
            return ex;
        }
    }
}