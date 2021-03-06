﻿using System;

public partial class TblCallsFull
{
    public int CallId { get; set; }
    public string CdrRecordType { get; set; }
    public string GlobalCallIdCallManagerId { get; set; }
    public string GlobalCallIdCallId { get; set; }
    public string OrigLegCallIdentifier { get; set; }
    public string DateTimeOrigination { get; set; }
    public string OrigNodeId { get; set; }
    public string OrigSpan { get; set; }
    public string OrigIpAddr { get; set; }
    public string CallingPartyNumber { get; set; }
    public string CallingPartyUnicodeLoginUserId { get; set; }
    public string OrigCauseLocation { get; set; }
    public string OrigCauseValue { get; set; }
    public string OrigPrecedenceLevel { get; set; }
    public string OrigMediaTransportAddressIp { get; set; }
    public string OrigMediaTransportAddressPort { get; set; }
    public string OrigMediaCapPayloadCapability { get; set; }
    public string OrigMediaCapMaxFramesPerPacket { get; set; }
    public string OrigMediaCapG723BitRate { get; set; }
    public string OrigVideoCapCodec { get; set; }
    public string OrigVideoCapBandwidth { get; set; }
    public string OrigVideoCapResolution { get; set; }
    public string OrigVideoTransportAddressIp { get; set; }
    public string OrigVideoTransportAddressPort { get; set; }
    public string OrigRsvpaudioStat { get; set; }
    public string OrigRsvpvideoStat { get; set; }
    public string DestLegIdentifier { get; set; }
    public string DestNodeId { get; set; }
    public string DestSpan { get; set; }
    public string DestIpAddr { get; set; }
    public string OriginalCalledPartyNumber { get; set; }
    public string FinalCalledPartyNumber { get; set; }
    public string FinalCalledPartyUnicodeLoginUserId { get; set; }
    public string DestCauseLocation { get; set; }
    public string DestCauseValue { get; set; }
    public string DestPrecedenceLevel { get; set; }
    public string DestMediaTransportAddressIp { get; set; }
    public string DestMediaTransportAddressPort { get; set; }
    public string DestMediaCapPayloadCapability { get; set; }
    public string DestMediaCapMaxFramesPerPacket { get; set; }
    public string DestMediaCapG723BitRate { get; set; }
    public string DestVideoCapCodec { get; set; }
    public string DestVideoCapBandwidth { get; set; }
    public string DestVideoCapResolution { get; set; }
    public string DestVideoTransportAddressIp { get; set; }
    public string DestVideoTransportAddressPort { get; set; }
    public string DestRsvpaudioStat { get; set; }
    public string DestRsvpvideoStat { get; set; }
    public string DateTimeConnect { get; set; }
    public DateTime? DateTimeDisconnect { get; set; }
    public string LastRedirectDn { get; set; }
    public Guid? Pkid { get; set; }
    public string OriginalCalledPartyNumberPartition { get; set; }
    public string CallingPartyNumberPartition { get; set; }
    public string FinalCalledPartyNumberPartition { get; set; }
    public string LastRedirectDnPartition { get; set; }
    public string Duration { get; set; }
    public string OrigDeviceName { get; set; }
    public string DestDeviceName { get; set; }
    public string OrigCallTerminationOnBehalfOf { get; set; }
    public string DestCallTerminationOnBehalfOf { get; set; }
    public string OrigCalledPartyRedirectOnBehalfOf { get; set; }
    public string LastRedirectRedirectOnBehalfOf { get; set; }
    public string OrigCalledPartyRedirectReason { get; set; }
    public string LastRedirectRedirectReason { get; set; }
    public string DestConversationId { get; set; }
    public string GlobalCallIdClusterId { get; set; }
    public string JoinOnBehalfOf { get; set; }
    public string Comment { get; set; }
    public string AuthCodeDescription { get; set; }
    public string AuthorizationLevel { get; set; }
    public string ClientMatterCode { get; set; }
    public string OrigDtmfmethod { get; set; }
    public string DestDtmfmethod { get; set; }
    public string CallSecuredStatus { get; set; }
    public string OrigConversationId { get; set; }
    public string OrigMediaCapBandwidth { get; set; }
    public string DestMediaCapBandwidth { get; set; }
    public string AuthorizationCodeValue { get; set; }
    public string OutpulsedCallingPartyNumber { get; set; }
    public string OutpulsedCalledPartyNumber { get; set; }
    public string OrigIpv4v6Addr { get; set; }
    public string DestIpv4v6Addr { get; set; }
    public string OrigVideoCapCodecChannel2 { get; set; }
    public string OrigVideoCapBandwidthChannel2 { get; set; }
    public string OrigVideoCapResolutionChannel2 { get; set; }
    public string OrigVideoTransportAddressIpChannel2 { get; set; }
    public string OrigVideoTransportAddressPortChannel2 { get; set; }
    public string OrigVideoChannelRoleChannel2 { get; set; }
    public string DestVideoCapCodecChannel2 { get; set; }
    public string DestVideoCapBandwidthChannel2 { get; set; }
    public string DestVideoCapResolutionChannel2 { get; set; }
    public string DestVideoTransportAddressIpChannel2 { get; set; }
    public string DestVideoTransportAddressPortChannel2 { get; set; }
    public string DestVideoChannelRoleChannel2 { get; set; }
}
