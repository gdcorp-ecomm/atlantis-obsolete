﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Atlantis.Framework.TrafficMobileTracking.Impl.MobileTrackingService {
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="MobileTrackingService.IfbiMobileTrackingService")]
    public interface IfbiMobileTrackingService {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IfbiMobileTrackingService/MobileClientData", ReplyAction="http://tempuri.org/IfbiMobileTrackingService/MobileClientDataResponse")]
        void MobileClientData(string deviceID, short mAppID, string appVersion, string OS, string OSVersion, string deviceModel, string deviceType, string shopperID, int plid, string webserviceAction, string clientIP, string clientCarrier, string webserviceLogData);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IfbiMobileTrackingService/MobileClientDataWithCICode", ReplyAction="http://tempuri.org/IfbiMobileTrackingService/MobileClientDataWithCICodeResponse")]
        void MobileClientDataWithCICode(string deviceID, short mAppID, string appVersion, string OS, string OSVersion, string deviceModel, string deviceType, string shopperID, int plid, string webserviceAction, string clientIP, string clientCarrier, string webserviceLogData, int ciCode);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public interface IfbiMobileTrackingServiceChannel : Atlantis.Framework.TrafficMobileTracking.Impl.MobileTrackingService.IfbiMobileTrackingService, System.ServiceModel.IClientChannel {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")]
    public partial class IfbiMobileTrackingServiceClient : System.ServiceModel.ClientBase<Atlantis.Framework.TrafficMobileTracking.Impl.MobileTrackingService.IfbiMobileTrackingService>, Atlantis.Framework.TrafficMobileTracking.Impl.MobileTrackingService.IfbiMobileTrackingService {
        
        public IfbiMobileTrackingServiceClient() {
        }
        
        public IfbiMobileTrackingServiceClient(string endpointConfigurationName) : 
                base(endpointConfigurationName) {
        }
        
        public IfbiMobileTrackingServiceClient(string endpointConfigurationName, string remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IfbiMobileTrackingServiceClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(endpointConfigurationName, remoteAddress) {
        }
        
        public IfbiMobileTrackingServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress) {
        }
        
        public void MobileClientData(string deviceID, short mAppID, string appVersion, string OS, string OSVersion, string deviceModel, string deviceType, string shopperID, int plid, string webserviceAction, string clientIP, string clientCarrier, string webserviceLogData) {
            base.Channel.MobileClientData(deviceID, mAppID, appVersion, OS, OSVersion, deviceModel, deviceType, shopperID, plid, webserviceAction, clientIP, clientCarrier, webserviceLogData);
        }
        
        public void MobileClientDataWithCICode(string deviceID, short mAppID, string appVersion, string OS, string OSVersion, string deviceModel, string deviceType, string shopperID, int plid, string webserviceAction, string clientIP, string clientCarrier, string webserviceLogData, int ciCode) {
            base.Channel.MobileClientDataWithCICode(deviceID, mAppID, appVersion, OS, OSVersion, deviceModel, deviceType, shopperID, plid, webserviceAction, clientIP, clientCarrier, webserviceLogData, ciCode);
        }
    }
}
