﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4200
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------



[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
[System.ServiceModel.ServiceContractAttribute(ConfigurationName="IDynamicTraffic")]
public interface IDynamicTraffic
{
    
    [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IDynamicTraffic/Process", ReplyAction="http://tempuri.org/IDynamicTraffic/ProcessResponse")]
    void Process(string searchResults, int templateID);
}

[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public interface IDynamicTrafficChannel : IDynamicTraffic, System.ServiceModel.IClientChannel
{
}

[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "3.0.0.0")]
public partial class DynamicTrafficClient : System.ServiceModel.ClientBase<IDynamicTraffic>, IDynamicTraffic
{
    
    public DynamicTrafficClient()
    {
    }
    
    public DynamicTrafficClient(string endpointConfigurationName) : 
            base(endpointConfigurationName)
    {
    }
    
    public DynamicTrafficClient(string endpointConfigurationName, string remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public DynamicTrafficClient(string endpointConfigurationName, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(endpointConfigurationName, remoteAddress)
    {
    }
    
    public DynamicTrafficClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
            base(binding, remoteAddress)
    {
    }
    
    public void Process(string searchResults, int templateID)
    {
        base.Channel.Process(searchResults, templateID);
    }
}
