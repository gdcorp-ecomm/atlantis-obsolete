using System;
using Atlantis.Framework.Interface;
using Atlantis.Framework.MYAGetDBPProductInfoData.Interface.PageHelper;

namespace Atlantis.Framework.MYAGetDBPProductInfoData.Interface
{
	public class GetDBPProductInfoRequestData : RequestData
	{
		
		#region Properties

		private int _plid;
		public int PrivateLabelId
		{
			get { return _plid; }
			set { _plid = value; }
		}

		private int _productTypeId;
		public int ProductTypeId
		{
			get { return _productTypeId; }
		}
		
		private PagingInfo _pagingInfo;
		public PageHelper.PagingInfo PagingInfo
		{
			get { return _pagingInfo; }
		}
		private TimeSpan _requestTimeout = new TimeSpan(0, 0, 2);
		public TimeSpan RequestTimeout
		{
			get { return _requestTimeout; }
			set { _requestTimeout = value; }
		}

		#endregion

		public GetDBPProductInfoRequestData(string shopperId,
		                                    string sourceUrl,
		                                    string orderId,
		                                    string pathway,
		                                    int pageCount,
																				PagingInfo pagingInfo,
																				int productTypeId, 
																				int privateLavelId)
			: base(shopperId, sourceUrl, orderId, pathway, pageCount)
		{
			_pagingInfo = pagingInfo;
			_productTypeId = productTypeId;
			_plid = privateLavelId;
		}

		public override string GetCacheMD5()
		{
			throw new NotImplementedException();
		}
	}
}