using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace Elv.NET.Contracts.Accessible.ContractDefinition
{


    public partial class AccessibleDeployment : AccessibleDeploymentBase
    {
        public AccessibleDeployment() : base(BYTECODE) { }
        public AccessibleDeployment(string byteCode) : base(byteCode) { }
    }

    public class AccessibleDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public AccessibleDeploymentBase() : base(BYTECODE) { }
        public AccessibleDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class CreatorFunction : CreatorFunctionBase { }

    [Function("creator", "address")]
    public class CreatorFunctionBase : FunctionMessage
    {

    }

    public partial class CanSeeFunction : CanSeeFunctionBase { }

    [Function("CAN_SEE", "uint8")]
    public class CanSeeFunctionBase : FunctionMessage
    {

    }

    public partial class AccessRequestV3Function : AccessRequestV3FunctionBase { }

    [Function("accessRequestV3", "bool")]
    public class AccessRequestV3FunctionBase : FunctionMessage
    {
        [Parameter("bytes32[]", "", 1)]
        public virtual List<byte[]> ReturnValue1 { get; set; }
        [Parameter("address[]", "", 2)]
        public virtual List<string> ReturnValue2 { get; set; }
    }

    public partial class VisibilityFunction : VisibilityFunctionBase { }

    [Function("visibility", "uint8")]
    public class VisibilityFunctionBase : FunctionMessage
    {

    }

    public partial class KillFunction : KillFunctionBase { }

    [Function("kill")]
    public class KillFunctionBase : FunctionMessage
    {

    }

    public partial class VersionFunction : VersionFunctionBase { }

    [Function("version", "bytes32")]
    public class VersionFunctionBase : FunctionMessage
    {

    }

    public partial class VersionAPIFunction : VersionAPIFunctionBase { }

    [Function("versionAPI", "bytes32")]
    public class VersionAPIFunctionBase : FunctionMessage
    {

    }

    public partial class IndexCategoryFunction : IndexCategoryFunctionBase { }

    [Function("indexCategory", "uint8")]
    public class IndexCategoryFunctionBase : FunctionMessage
    {

    }

    public partial class TransferCreatorshipFunction : TransferCreatorshipFunctionBase { }

    [Function("transferCreatorship")]
    public class TransferCreatorshipFunctionBase : FunctionMessage
    {
        [Parameter("address", "newCreator", 1)]
        public virtual string NewCreator { get; set; }
    }

    public partial class OwnerFunction : OwnerFunctionBase { }

    [Function("owner", "address")]
    public class OwnerFunctionBase : FunctionMessage
    {

    }

    public partial class HasAccessFunction : HasAccessFunctionBase { }

    [Function("hasAccess", "bool")]
    public class HasAccessFunctionBase : FunctionMessage
    {
        [Parameter("address", "candidate", 1)]
        public virtual string Candidate { get; set; }
    }

    public partial class CanAccessFunction : CanAccessFunctionBase { }

    [Function("CAN_ACCESS", "uint8")]
    public class CanAccessFunctionBase : FunctionMessage
    {

    }

    public partial class SetVisibilityFunction : SetVisibilityFunctionBase { }

    [Function("setVisibility")]
    public class SetVisibilityFunctionBase : FunctionMessage
    {
        [Parameter("uint8", "_visibility_code", 1)]
        public virtual byte VisibilityCode { get; set; }
    }

    public partial class ContentSpaceFunction : ContentSpaceFunctionBase { }

    [Function("contentSpace", "address")]
    public class ContentSpaceFunctionBase : FunctionMessage
    {

    }

    public partial class CanEditFunction : CanEditFunctionBase { }

    [Function("CAN_EDIT", "uint8")]
    public class CanEditFunctionBase : FunctionMessage
    {

    }

    public partial class TransferOwnershipFunction : TransferOwnershipFunctionBase { }

    [Function("transferOwnership")]
    public class TransferOwnershipFunctionBase : FunctionMessage
    {
        [Parameter("address", "newOwner", 1)]
        public virtual string NewOwner { get; set; }
    }

    public partial class AccessRequestV3EventDTO : AccessRequestV3EventDTOBase { }

    [Event("AccessRequestV3")]
    public class AccessRequestV3EventDTOBase : IEventDTO
    {
        [Parameter("uint256", "requestNonce", 1, false )]
        public virtual BigInteger RequestNonce { get; set; }
        [Parameter("address", "parentAddress", 2, false )]
        public virtual string ParentAddress { get; set; }
        [Parameter("bytes32", "contextHash", 3, false )]
        public virtual byte[] ContextHash { get; set; }
        [Parameter("address", "accessor", 4, false )]
        public virtual string Accessor { get; set; }
        [Parameter("uint256", "requestTimestamp", 5, false )]
        public virtual BigInteger RequestTimestamp { get; set; }
    }

    public partial class VisibilityChangedEventDTO : VisibilityChangedEventDTOBase { }

    [Event("VisibilityChanged")]
    public class VisibilityChangedEventDTOBase : IEventDTO
    {
        [Parameter("address", "contentSpace", 1, false )]
        public virtual string ContentSpace { get; set; }
        [Parameter("address", "parentAddress", 2, false )]
        public virtual string ParentAddress { get; set; }
        [Parameter("uint8", "visibility", 3, false )]
        public virtual byte Visibility { get; set; }
    }

    public partial class CreatorOutputDTO : CreatorOutputDTOBase { }

    [FunctionOutput]
    public class CreatorOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class CanSeeOutputDTO : CanSeeOutputDTOBase { }

    [FunctionOutput]
    public class CanSeeOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }



    public partial class VisibilityOutputDTO : VisibilityOutputDTOBase { }

    [FunctionOutput]
    public class VisibilityOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }



    public partial class VersionOutputDTO : VersionOutputDTOBase { }

    [FunctionOutput]
    public class VersionOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class VersionAPIOutputDTO : VersionAPIOutputDTOBase { }

    [FunctionOutput]
    public class VersionAPIOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bytes32", "", 1)]
        public virtual byte[] ReturnValue1 { get; set; }
    }

    public partial class IndexCategoryOutputDTO : IndexCategoryOutputDTOBase { }

    [FunctionOutput]
    public class IndexCategoryOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }



    public partial class OwnerOutputDTO : OwnerOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class HasAccessOutputDTO : HasAccessOutputDTOBase { }

    [FunctionOutput]
    public class HasAccessOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class CanAccessOutputDTO : CanAccessOutputDTOBase { }

    [FunctionOutput]
    public class CanAccessOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }



    public partial class ContentSpaceOutputDTO : ContentSpaceOutputDTOBase { }

    [FunctionOutput]
    public class ContentSpaceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class CanEditOutputDTO : CanEditOutputDTOBase { }

    [FunctionOutput]
    public class CanEditOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint8", "", 1)]
        public virtual byte ReturnValue1 { get; set; }
    }


}
