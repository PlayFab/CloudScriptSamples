using System;
using System.Collections.Generic;
using PlayFab.Internal;
using PlayFab.Serialization.JsonFx;

namespace PlayFab.ClientModels
{
	
	
	
	public class AddFriendRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab identifier of the user to attempt to add to the local user's friend list
		/// </summary>
		
		public string FriendPlayFabId { get; set;}
		
		/// <summary>
		/// PlayFab username of the user to attempt to add to the local user's friend list
		/// </summary>
		
		public string FriendUsername { get; set;}
		
		/// <summary>
		/// email address of the user to attempt to add to the local user's friend list
		/// </summary>
		
		public string FriendEmail { get; set;}
		
		/// <summary>
		/// title-specific display name of the user to attempt to add to the local user's friend list
		/// </summary>
		
		public string FriendTitleDisplayName { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("FriendPlayFabId", FriendPlayFabId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("FriendUsername", FriendUsername);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("FriendEmail", FriendEmail);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("FriendTitleDisplayName", FriendTitleDisplayName);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			FriendPlayFabId = (string)JsonUtil.Get<string>(json, "FriendPlayFabId");
			FriendUsername = (string)JsonUtil.Get<string>(json, "FriendUsername");
			FriendEmail = (string)JsonUtil.Get<string>(json, "FriendEmail");
			FriendTitleDisplayName = (string)JsonUtil.Get<string>(json, "FriendTitleDisplayName");
		}
	}
	
	
	
	public class AddFriendResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// was the friend request processed successfully
		/// </summary>
		
		public bool Created { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("Created", Created);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Created = (bool)JsonUtil.Get<bool?>(json, "Created");
		}
	}
	
	
	
	public class AddSharedGroupMembersRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the shared group
		/// </summary>
		
		public string SharedGroupId { get; set;}
		
		/// <summary>
		/// list of PlayFabId identifiers of users to add as members of the shared group
		/// </summary>
		
		public List<string> PlayFabIds { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("SharedGroupId", SharedGroupId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("PlayFabIds", PlayFabIds);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			SharedGroupId = (string)JsonUtil.Get<string>(json, "SharedGroupId");
			PlayFabIds = JsonUtil.GetList<string>(json, "PlayFabIds");
		}
	}
	
	
	
	public class AddSharedGroupMembersResult : PlayFabModelBase
	{
		
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class AddUsernamePasswordRequest : PlayFabModelBase
	{
		
		
		
		public string Username { get; set;}
		
		
		public string Email { get; set;}
		
		
		public string Password { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("Username", Username);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Email", Email);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Password", Password);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Username = (string)JsonUtil.Get<string>(json, "Username");
			Email = (string)JsonUtil.Get<string>(json, "Email");
			Password = (string)JsonUtil.Get<string>(json, "Password");
		}
	}
	
	
	
	public class AddUsernamePasswordResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique user name
		/// </summary>
		
		public string Username { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("Username", Username);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Username = (string)JsonUtil.Get<string>(json, "Username");
		}
	}
	
	
	
	public class AddUserVirtualCurrencyRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// name of the virtual currency which is to be incremented
		/// </summary>
		
		public string VirtualCurrency { get; set;}
		
		/// <summary>
		/// amount to be added to the user balance of the specified virtual currency
		/// </summary>
		
		public int Amount { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("VirtualCurrency", VirtualCurrency);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Amount", Amount);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			VirtualCurrency = (string)JsonUtil.Get<string>(json, "VirtualCurrency");
			Amount = (int)JsonUtil.Get<double?>(json, "Amount");
		}
	}
	
	
	
	public class AndroidDevicePushNotificationRegistrationRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// the Registration ID provided by the Google Cloud Messaging service when the title registered to receive push notifications (see the GCM documentation, here: http://developer.android.com/google/gcm/client.html)
		/// </summary>
		
		public string DeviceToken { get; set;}
		
		/// <summary>
		/// If true, send a test push message immediately after sucessful registration. Defaults to false.
		/// </summary>
		
		public bool? SendPushNotificationConfirmation { get; set;}
		
		/// <summary>
		/// Message to display when confirming push notification.
		/// </summary>
		
		public string ConfirmationMessege { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("DeviceToken", DeviceToken);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("SendPushNotificationConfirmation", SendPushNotificationConfirmation);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("ConfirmationMessege", ConfirmationMessege);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			DeviceToken = (string)JsonUtil.Get<string>(json, "DeviceToken");
			SendPushNotificationConfirmation = (bool?)JsonUtil.Get<bool?>(json, "SendPushNotificationConfirmation");
			ConfirmationMessege = (string)JsonUtil.Get<string>(json, "ConfirmationMessege");
		}
	}
	
	
	
	public class AndroidDevicePushNotificationRegistrationResult : PlayFabModelBase
	{
		
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class CartItem : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the catalog item
		/// </summary>
		
		public string ItemId { get; set;}
		
		/// <summary>
		/// class name to which catalog item belongs
		/// </summary>
		
		public string ItemClass { get; set;}
		
		/// <summary>
		/// unique instance identifier for this catalog item
		/// </summary>
		
		public string ItemInstanceId { get; set;}
		
		/// <summary>
		/// display name for the catalog item
		/// </summary>
		
		public string DisplayName { get; set;}
		
		/// <summary>
		/// description of the catalog item
		/// </summary>
		
		public string Description { get; set;}
		
		/// <summary>
		/// the cost of the catalog item for each applicable virtual currency
		/// </summary>
		
		public Dictionary<string,uint> VirtualCurrencyPrices { get; set;}
		
		/// <summary>
		/// the cost of the catalog item for each applicable real world currency
		/// </summary>
		
		public Dictionary<string,uint> RealCurrencyPrices { get; set;}
		
		/// <summary>
		/// the amount of each applicable virtual currency which will be received as a result of purchasing this catalog item
		/// </summary>
		
		public Dictionary<string,uint> VCAmount { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("ItemId", ItemId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("ItemClass", ItemClass);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("ItemInstanceId", ItemInstanceId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("DisplayName", DisplayName);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Description", Description);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("VirtualCurrencyPrices", VirtualCurrencyPrices);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("RealCurrencyPrices", RealCurrencyPrices);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("VCAmount", VCAmount);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ItemId = (string)JsonUtil.Get<string>(json, "ItemId");
			ItemClass = (string)JsonUtil.Get<string>(json, "ItemClass");
			ItemInstanceId = (string)JsonUtil.Get<string>(json, "ItemInstanceId");
			DisplayName = (string)JsonUtil.Get<string>(json, "DisplayName");
			Description = (string)JsonUtil.Get<string>(json, "Description");
			VirtualCurrencyPrices = JsonUtil.GetDictionaryUInt32(json, "VirtualCurrencyPrices");
			RealCurrencyPrices = JsonUtil.GetDictionaryUInt32(json, "RealCurrencyPrices");
			VCAmount = JsonUtil.GetDictionaryUInt32(json, "VCAmount");
		}
	}
	
	
	
	/// <summary>
	/// A purchasable item from the item catalog
	/// </summary>
	public class CatalogItem : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for this item
		/// </summary>
		
		public string ItemId { get; set;}
		
		/// <summary>
		/// class to which the item belongs
		/// </summary>
		
		public string ItemClass { get; set;}
		
		/// <summary>
		/// catalog item for this item
		/// </summary>
		
		public string CatalogVersion { get; set;}
		
		/// <summary>
		/// text name for the item, to show in-game
		/// </summary>
		
		public string DisplayName { get; set;}
		
		/// <summary>
		/// text description of item, to show in-game
		/// </summary>
		
		public string Description { get; set;}
		
		/// <summary>
		/// price of this item in virtual currencies and "RM" (the base Real Money purchase price, in USD pennies)
		/// </summary>
		
		public Dictionary<string,uint> VirtualCurrencyPrices { get; set;}
		
		/// <summary>
		/// override prices for this item for specific currencies
		/// </summary>
		
		public Dictionary<string,uint> RealCurrencyPrices { get; set;}
		
		/// <summary>
		/// list of item tags
		/// </summary>
		
		public List<string> Tags { get; set;}
		
		/// <summary>
		/// game specific custom data
		/// </summary>
		
		public string CustomData { get; set;}
		
		/// <summary>
		/// array of ItemId values which are evaluated when any item is added to the player inventory - if all items in this array are present, the this item will also be added to the player inventory
		/// </summary>
		
		public List<string> GrantedIfPlayerHas { get; set;}
		
		/// <summary>
		/// defines the consumable properties (number of uses, timeout) for the item
		/// </summary>
		
		public CatalogItemConsumableInfo Consumable { get; set;}
		
		/// <summary>
		/// defines the container properties for the item - what items it contains, including random drop tables and virtual currencies, and what item (if any) is required to open it via the UnlockContainerItem API
		/// </summary>
		
		public CatalogItemContainerInfo Container { get; set;}
		
		/// <summary>
		/// defines the bundle properties for the item - bundles are items which contain other items, including random drop tables and virtual currencies
		/// </summary>
		
		public CatalogItemBundleInfo Bundle { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("ItemId", ItemId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("ItemClass", ItemClass);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("CatalogVersion", CatalogVersion);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("DisplayName", DisplayName);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Description", Description);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("VirtualCurrencyPrices", VirtualCurrencyPrices);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("RealCurrencyPrices", RealCurrencyPrices);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Tags", Tags);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("CustomData", CustomData);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("GrantedIfPlayerHas", GrantedIfPlayerHas);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Consumable", Consumable);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Container", Container);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Bundle", Bundle);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ItemId = (string)JsonUtil.Get<string>(json, "ItemId");
			ItemClass = (string)JsonUtil.Get<string>(json, "ItemClass");
			CatalogVersion = (string)JsonUtil.Get<string>(json, "CatalogVersion");
			DisplayName = (string)JsonUtil.Get<string>(json, "DisplayName");
			Description = (string)JsonUtil.Get<string>(json, "Description");
			VirtualCurrencyPrices = JsonUtil.GetDictionaryUInt32(json, "VirtualCurrencyPrices");
			RealCurrencyPrices = JsonUtil.GetDictionaryUInt32(json, "RealCurrencyPrices");
			Tags = JsonUtil.GetList<string>(json, "Tags");
			CustomData = (string)JsonUtil.Get<string>(json, "CustomData");
			GrantedIfPlayerHas = JsonUtil.GetList<string>(json, "GrantedIfPlayerHas");
			Consumable = JsonUtil.GetObject<CatalogItemConsumableInfo>(json, "Consumable");
			Container = JsonUtil.GetObject<CatalogItemContainerInfo>(json, "Container");
			Bundle = JsonUtil.GetObject<CatalogItemBundleInfo>(json, "Bundle");
		}
	}
	
	
	
	public class CatalogItemBundleInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique ItemId values for all items which will be added to the player inventory when the bundle is added
		/// </summary>
		
		public List<string> BundledItems { get; set;}
		
		/// <summary>
		/// unique TableId values for all RandomResultTable objects which are part of the bundle (random tables will be resolved and add the relevant items to the player inventory when the bundle is added)
		/// </summary>
		
		public List<string> BundledResultTables { get; set;}
		
		/// <summary>
		/// virtual currency types and balances which will be added to the player inventory when the bundle is added
		/// </summary>
		
		public Dictionary<string,uint> BundledVirtualCurrencies { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("BundledItems", BundledItems);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("BundledResultTables", BundledResultTables);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("BundledVirtualCurrencies", BundledVirtualCurrencies);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			BundledItems = JsonUtil.GetList<string>(json, "BundledItems");
			BundledResultTables = JsonUtil.GetList<string>(json, "BundledResultTables");
			BundledVirtualCurrencies = JsonUtil.GetDictionaryUInt32(json, "BundledVirtualCurrencies");
		}
	}
	
	
	
	public class CatalogItemConsumableInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// number of times this object can be used, after which it will be removed from the player inventory
		/// </summary>
		
		public uint? UsageCount { get; set;}
		
		/// <summary>
		/// duration in seconds for how long the item will remain in the player inventory - once elapsed, the item will be removed
		/// </summary>
		
		public uint? UsagePeriod { get; set;}
		
		/// <summary>
		/// all inventory item instances in the player inventory sharing a non-null UsagePeriodGroup have their UsagePeriod values added together, and share the result - when that period has elapsed, all the items in the group will be removed
		/// </summary>
		
		public string UsagePeriodGroup { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("UsageCount", UsageCount);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("UsagePeriod", UsagePeriod);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("UsagePeriodGroup", UsagePeriodGroup);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			UsageCount = (uint?)JsonUtil.Get<double?>(json, "UsageCount");
			UsagePeriod = (uint?)JsonUtil.Get<double?>(json, "UsagePeriod");
			UsagePeriodGroup = (string)JsonUtil.Get<string>(json, "UsagePeriodGroup");
		}
	}
	
	
	
	/// <summary>
	/// Containers are inventory items that can hold other items defined in the catalog, as well as virtual currency, which is added to the player inventory when the container is unlocked, using the UnlockContainerItem API. The items can be anything defined in the catalog, as well as RandomResultTable objects which will be resolved when the container is unlocked. Containers and their keys should be defined as Consumable (having a limited number of uses) in their catalog defintiions, unless the intent is for the player to be able to re-use them infinitely.
	/// </summary>
	public class CatalogItemContainerInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// ItemId for the catalog item used to unlock the container, if any (if not specified, a call to UnlockContainerItem will open the container, adding the contents to the player inventory and currency balances)
		/// </summary>
		
		public string KeyItemId { get; set;}
		
		/// <summary>
		/// unique ItemId values for all items which will be added to the player inventory, once the container has been unlocked
		/// </summary>
		
		public List<string> ItemContents { get; set;}
		
		/// <summary>
		/// unique TableId values for all RandomResultTable objects which are part of the container (once unlocked, random tables will be resolved and add the relevant items to the player inventory)
		/// </summary>
		
		public List<string> ResultTableContents { get; set;}
		
		/// <summary>
		/// virtual currency types and balances which will be added to the player inventory when the container is unlocked
		/// </summary>
		
		public Dictionary<string,uint> VirtualCurrencyContents { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("KeyItemId", KeyItemId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("ItemContents", ItemContents);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("ResultTableContents", ResultTableContents);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("VirtualCurrencyContents", VirtualCurrencyContents);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			KeyItemId = (string)JsonUtil.Get<string>(json, "KeyItemId");
			ItemContents = JsonUtil.GetList<string>(json, "ItemContents");
			ResultTableContents = JsonUtil.GetList<string>(json, "ResultTableContents");
			VirtualCurrencyContents = JsonUtil.GetDictionaryUInt32(json, "VirtualCurrencyContents");
		}
	}
	
	
	
	public class ConfirmPurchaseRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// purchase order identifier returned from StartPurchase
		/// </summary>
		
		public string OrderId { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("OrderId", OrderId);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			OrderId = (string)JsonUtil.Get<string>(json, "OrderId");
		}
	}
	
	
	
	public class ConfirmPurchaseResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// purchase order identifier
		/// </summary>
		
		public string OrderId { get; set;}
		
		/// <summary>
		/// date and time of the purchase
		/// </summary>
		
		public DateTime PurchaseDate { get; set;}
		
		/// <summary>
		/// array of items purchased
		/// </summary>
		
		public List<PurchasedItem> Items { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("OrderId", OrderId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("PurchaseDate", PurchaseDate);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Items", Items);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			OrderId = (string)JsonUtil.Get<string>(json, "OrderId");
			PurchaseDate = (DateTime)JsonUtil.GetDateTime(json, "PurchaseDate");
			Items = JsonUtil.GetObjectList<PurchasedItem>(json, "Items");
		}
	}
	
	
	
	public class ConsumeItemRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique instance identifier of the item to be consumed
		/// </summary>
		
		public string ItemInstanceId { get; set;}
		
		/// <summary>
		/// number of uses to consume from the item
		/// </summary>
		
		public int ConsumeCount { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("ItemInstanceId", ItemInstanceId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("ConsumeCount", ConsumeCount);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ItemInstanceId = (string)JsonUtil.Get<string>(json, "ItemInstanceId");
			ConsumeCount = (int)JsonUtil.Get<double?>(json, "ConsumeCount");
		}
	}
	
	
	
	public class ConsumeItemResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique instance identifier of the item with uses consumed
		/// </summary>
		
		public string ItemInstanceId { get; set;}
		
		/// <summary>
		/// number of uses remaining on the item
		/// </summary>
		
		public int RemainingUses { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("ItemInstanceId", ItemInstanceId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("RemainingUses", RemainingUses);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ItemInstanceId = (string)JsonUtil.Get<string>(json, "ItemInstanceId");
			RemainingUses = (int)JsonUtil.Get<double?>(json, "RemainingUses");
		}
	}
	
	
	
	public class CreateSharedGroupRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the shared group (a random identifier will be assigned, if one is not specified)
		/// </summary>
		
		public string SharedGroupId { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("SharedGroupId", SharedGroupId);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			SharedGroupId = (string)JsonUtil.Get<string>(json, "SharedGroupId");
		}
	}
	
	
	
	public class CreateSharedGroupResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the shared group
		/// </summary>
		
		public string SharedGroupId { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("SharedGroupId", SharedGroupId);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			SharedGroupId = (string)JsonUtil.Get<string>(json, "SharedGroupId");
		}
	}
	
	
	
	public enum Currency
	{
		USD,
		GBP,
		EUR,
		RUB,
		BRL,
		CIS,
		CAD
	}
	
	
	
	public class CurrentGamesRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// region to check for game instances
		/// </summary>
		
		public Region? Region { get; set;}
		
		/// <summary>
		/// version of build to match against
		/// </summary>
		
		public string BuildVersion { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("Region", Region);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("BuildVersion", BuildVersion);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Region = (Region?)JsonUtil.GetEnum<Region>(json, "Region");
			BuildVersion = (string)JsonUtil.Get<string>(json, "BuildVersion");
		}
	}
	
	
	
	public class CurrentGamesResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of games found
		/// </summary>
		
		public List<GameInfo> Games { get; set;}
		
		/// <summary>
		/// total number of players across all servers
		/// </summary>
		
		public int PlayerCount { get; set;}
		
		/// <summary>
		/// number of games running
		/// </summary>
		
		public int GameCount { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("Games", Games);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("PlayerCount", PlayerCount);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("GameCount", GameCount);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Games = JsonUtil.GetObjectList<GameInfo>(json, "Games");
			PlayerCount = (int)JsonUtil.Get<double?>(json, "PlayerCount");
			GameCount = (int)JsonUtil.Get<double?>(json, "GameCount");
		}
	}
	
	
	
	public class EmptyResult : PlayFabModelBase
	{
		
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class FacebookPlayFabIdPair : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique Facebook identifier for a user
		/// </summary>
		
		public string FacebookId { get; set;}
		
		/// <summary>
		/// unique PlayFab identifier for a user, or null if no PlayFab account is linked to the Facebook identifier
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("FacebookId", FacebookId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("PlayFabId", PlayFabId);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			FacebookId = (string)JsonUtil.Get<string>(json, "FacebookId");
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
		}
	}
	
	
	
	public class FriendInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier for this friend
		/// </summary>
		
		public string FriendPlayFabId { get; set;}
		
		/// <summary>
		/// PlayFab unique username for this friend
		/// </summary>
		
		public string Username { get; set;}
		
		/// <summary>
		/// title-specific display name for this friend
		/// </summary>
		
		public string TitleDisplayName { get; set;}
		
		/// <summary>
		/// tags which have been associated with this friend
		/// </summary>
		
		public List<string> Tags { get; set;}
		
		/// <summary>
		/// unique lobby identifier of the Game Server Instance to which this player is currently connected
		/// </summary>
		
		public string CurrentMatchmakerLobbyId { get; set;}
		
		/// <summary>
		/// available Facebook information (if the user and PlayFab friend are also connected in Facebook)
		/// </summary>
		
		public UserFacebookInfo FacebookInfo { get; set;}
		
		/// <summary>
		/// available Steam information (if the user and PlayFab friend are also connected in Steam)
		/// </summary>
		
		public UserSteamInfo SteamInfo { get; set;}
		
		/// <summary>
		/// available Game Center information (if the user and PlayFab friend are also connected in Game Center)
		/// </summary>
		
		public UserGameCenterInfo GameCenterInfo { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("FriendPlayFabId", FriendPlayFabId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Username", Username);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("TitleDisplayName", TitleDisplayName);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Tags", Tags);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("CurrentMatchmakerLobbyId", CurrentMatchmakerLobbyId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("FacebookInfo", FacebookInfo);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("SteamInfo", SteamInfo);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("GameCenterInfo", GameCenterInfo);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			FriendPlayFabId = (string)JsonUtil.Get<string>(json, "FriendPlayFabId");
			Username = (string)JsonUtil.Get<string>(json, "Username");
			TitleDisplayName = (string)JsonUtil.Get<string>(json, "TitleDisplayName");
			Tags = JsonUtil.GetList<string>(json, "Tags");
			CurrentMatchmakerLobbyId = (string)JsonUtil.Get<string>(json, "CurrentMatchmakerLobbyId");
			FacebookInfo = JsonUtil.GetObject<UserFacebookInfo>(json, "FacebookInfo");
			SteamInfo = JsonUtil.GetObject<UserSteamInfo>(json, "SteamInfo");
			GameCenterInfo = JsonUtil.GetObject<UserGameCenterInfo>(json, "GameCenterInfo");
		}
	}
	
	
	
	public class GameInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// region to which this server is associated
		/// </summary>
		
		public Region? Region { get; set;}
		
		/// <summary>
		/// unique lobby identifier for this game server
		/// </summary>
		
		public string LobbyID { get; set;}
		
		/// <summary>
		/// build version this server is running
		/// </summary>
		
		public string BuildVersion { get; set;}
		
		/// <summary>
		/// game mode this server is running
		/// </summary>
		
		public string GameMode { get; set;}
		
		/// <summary>
		/// maximum players this server can support
		/// </summary>
		
		public int? MaxPlayers { get; set;}
		
		/// <summary>
		/// array of strings of current player names on this server (note that these are PlayFab usernames, as opposed to title display names)
		/// </summary>
		
		public List<string> PlayerUserIds { get; set;}
		
		/// <summary>
		/// duration in seconds this server has been running
		/// </summary>
		
		public uint RunTime { get; set;}
		
		/// <summary>
		/// game specific string denoting server configuration
		/// </summary>
		
		public string GameServerState { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("Region", Region);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("LobbyID", LobbyID);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("BuildVersion", BuildVersion);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("GameMode", GameMode);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("MaxPlayers", MaxPlayers);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("PlayerUserIds", PlayerUserIds);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("RunTime", RunTime);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("GameServerState", GameServerState);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Region = (Region?)JsonUtil.GetEnum<Region>(json, "Region");
			LobbyID = (string)JsonUtil.Get<string>(json, "LobbyID");
			BuildVersion = (string)JsonUtil.Get<string>(json, "BuildVersion");
			GameMode = (string)JsonUtil.Get<string>(json, "GameMode");
			MaxPlayers = (int?)JsonUtil.Get<double?>(json, "MaxPlayers");
			PlayerUserIds = JsonUtil.GetList<string>(json, "PlayerUserIds");
			RunTime = (uint)JsonUtil.Get<double?>(json, "RunTime");
			GameServerState = (string)JsonUtil.Get<string>(json, "GameServerState");
		}
	}
	
	
	
	public class GameServerRegionsRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// version of game server for which stats are being requested
		/// </summary>
		
		public string BuildVersion { get; set;}
		
		
		public string TitleId { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("BuildVersion", BuildVersion);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("TitleId", TitleId);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			BuildVersion = (string)JsonUtil.Get<string>(json, "BuildVersion");
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
		}
	}
	
	
	
	public class GameServerRegionsResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of regions found matching the request parameters
		/// </summary>
		
		public List<RegionInfo> Regions { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("Regions", Regions);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Regions = JsonUtil.GetObjectList<RegionInfo>(json, "Regions");
		}
	}
	
	
	
	public class GetAccountInfoRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFabId of the user to load data for. Optional, defaults to yourself if not set.
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("PlayFabId", PlayFabId);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
		}
	}
	
	
	
	public class GetAccountInfoResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// account information for the local user
		/// </summary>
		
		public UserAccountInfo AccountInfo { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("AccountInfo", AccountInfo);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			AccountInfo = JsonUtil.GetObject<UserAccountInfo>(json, "AccountInfo");
		}
	}
	
	
	
	public class GetCatalogItemsRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// which catalog is being requested
		/// </summary>
		
		public string CatalogVersion { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("CatalogVersion", CatalogVersion);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			CatalogVersion = (string)JsonUtil.Get<string>(json, "CatalogVersion");
		}
	}
	
	
	
	public class GetCatalogItemsResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of inventory objects
		/// </summary>
		
		public List<CatalogItem> Catalog { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("Catalog", Catalog);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Catalog = JsonUtil.GetObjectList<CatalogItem>(json, "Catalog");
		}
	}
	
	
	
	public class GetCloudScriptUrlRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// the Cloud Script Version to use (defaults to 1)
		/// </summary>
		
		public int? Version { get; set;}
		
		/// <summary>
		/// specifies whether the URL returned should be the one for the most recently uploaded Revision of the Cloud Script (true), or the Revision most recently set to live (false - the default)
		/// </summary>
		
		public bool? Testing { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("Version", Version);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Testing", Testing);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Version = (int?)JsonUtil.Get<double?>(json, "Version");
			Testing = (bool?)JsonUtil.Get<bool?>(json, "Testing");
		}
	}
	
	
	
	public class GetCloudScriptUrlResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// URL of the Cloud Script logic server
		/// </summary>
		
		public string Url { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("Url", Url);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Url = (string)JsonUtil.Get<string>(json, "Url");
		}
	}
	
	
	
	public class GetFriendLeaderboardRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// statistic used to rank friends for this leaderboard
		/// </summary>
		
		public string StatisticName { get; set;}
		
		/// <summary>
		/// position in the leaderboard to start this listing (defaults to the first entry)
		/// </summary>
		
		public int StartPosition { get; set;}
		
		/// <summary>
		/// maximum number of entries to retrieve
		/// </summary>
		
		public int MaxResultsCount { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("StatisticName", StatisticName);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("StartPosition", StartPosition);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("MaxResultsCount", MaxResultsCount);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			StatisticName = (string)JsonUtil.Get<string>(json, "StatisticName");
			StartPosition = (int)JsonUtil.Get<double?>(json, "StartPosition");
			MaxResultsCount = (int)JsonUtil.Get<double?>(json, "MaxResultsCount");
		}
	}
	
	
	
	public class GetFriendsListRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// indicates whether Steam service friends should also be included in the response
		/// </summary>
		
		public bool? IncludeSteamFriends { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("IncludeSteamFriends", IncludeSteamFriends);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			IncludeSteamFriends = (bool?)JsonUtil.Get<bool?>(json, "IncludeSteamFriends");
		}
	}
	
	
	
	public class GetFriendsListResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of friends found
		/// </summary>
		
		public List<FriendInfo> Friends { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("Friends", Friends);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Friends = JsonUtil.GetObjectList<FriendInfo>(json, "Friends");
		}
	}
	
	
	
	public class GetLeaderboardAroundCurrentUserRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// statistic used to rank players for this leaderboard
		/// </summary>
		
		public string StatisticName { get; set;}
		
		/// <summary>
		/// maximum number of entries to retrieve
		/// </summary>
		
		public int MaxResultsCount { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("StatisticName", StatisticName);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("MaxResultsCount", MaxResultsCount);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			StatisticName = (string)JsonUtil.Get<string>(json, "StatisticName");
			MaxResultsCount = (int)JsonUtil.Get<double?>(json, "MaxResultsCount");
		}
	}
	
	
	
	public class GetLeaderboardAroundCurrentUserResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// ordered listing of users and their positions in the requested leaderboard
		/// </summary>
		
		public List<PlayerLeaderboardEntry> Leaderboard { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("Leaderboard", Leaderboard);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Leaderboard = JsonUtil.GetObjectList<PlayerLeaderboardEntry>(json, "Leaderboard");
		}
	}
	
	
	
	public class GetLeaderboardRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// statistic used to rank players for this leaderboard
		/// </summary>
		
		public string StatisticName { get; set;}
		
		/// <summary>
		/// position in the leaderboard to start this listing (defaults to the first entry)
		/// </summary>
		
		public int StartPosition { get; set;}
		
		/// <summary>
		/// maximum number of entries to retrieve
		/// </summary>
		
		public int MaxResultsCount { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("StatisticName", StatisticName);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("StartPosition", StartPosition);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("MaxResultsCount", MaxResultsCount);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			StatisticName = (string)JsonUtil.Get<string>(json, "StatisticName");
			StartPosition = (int)JsonUtil.Get<double?>(json, "StartPosition");
			MaxResultsCount = (int)JsonUtil.Get<double?>(json, "MaxResultsCount");
		}
	}
	
	
	
	public class GetLeaderboardResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// ordered listing of users and their positions in the requested leaderboard
		/// </summary>
		
		public List<PlayerLeaderboardEntry> Leaderboard { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("Leaderboard", Leaderboard);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Leaderboard = JsonUtil.GetObjectList<PlayerLeaderboardEntry>(json, "Leaderboard");
		}
	}
	
	
	
	public class GetPlayFabIDsFromFacebookIDsRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of unique Facebook identifiers for which the title needs to get PlayFab identifiers
		/// </summary>
		
		public List<string> FacebookIDs { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("FacebookIDs", FacebookIDs);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			FacebookIDs = JsonUtil.GetList<string>(json, "FacebookIDs");
		}
	}
	
	
	
	public class GetPlayFabIDsFromFacebookIDsResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// mapping of Facebook identifiers to PlayFab identifiers
		/// </summary>
		
		public List<FacebookPlayFabIdPair> Data { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("Data", Data);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Data = JsonUtil.GetObjectList<FacebookPlayFabIdPair>(json, "Data");
		}
	}
	
	
	
	public class GetPublisherDataRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		///  array of keys to get back data from the Publisher data blob, set by the admin tools
		/// </summary>
		
		public List<string> Keys { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("Keys", Keys);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Keys = JsonUtil.GetList<string>(json, "Keys");
		}
	}
	
	
	
	public class GetPublisherDataResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// a dictionary object of key / value pairs
		/// </summary>
		
		public Dictionary<string,string> Data { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("Data", Data);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Data = JsonUtil.GetDictionary<string>(json, "Data");
		}
	}
	
	
	
	public class GetSharedGroupDataRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the shared group
		/// </summary>
		
		public string SharedGroupId { get; set;}
		
		/// <summary>
		/// specific keys to retrieve from the shared group (if not specified, all keys will be returned, while an empty array indicates that no keys should be returned)
		/// </summary>
		
		public List<string> Keys { get; set;}
		
		/// <summary>
		/// if true, return the list of all members of the shared group
		/// </summary>
		
		public bool? GetMembers { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("SharedGroupId", SharedGroupId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Keys", Keys);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("GetMembers", GetMembers);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			SharedGroupId = (string)JsonUtil.Get<string>(json, "SharedGroupId");
			Keys = JsonUtil.GetList<string>(json, "Keys");
			GetMembers = (bool?)JsonUtil.Get<bool?>(json, "GetMembers");
		}
	}
	
	
	
	public class GetSharedGroupDataResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// data for the requested keys
		/// </summary>
		
		public Dictionary<string,SharedGroupDataRecord> Data { get; set;}
		
		/// <summary>
		/// list of PlayFabId identifiers for the members of this group, if requested
		/// </summary>
		
		public List<string> Members { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("Data", Data);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Members", Members);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Data = JsonUtil.GetObjectDictionary<SharedGroupDataRecord>(json, "Data");
			Members = JsonUtil.GetList<string>(json, "Members");
		}
	}
	
	
	
	public class GetStoreItemsRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unqiue identifier for the store which is being requested
		/// </summary>
		
		public string StoreId { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("StoreId", StoreId);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			StoreId = (string)JsonUtil.Get<string>(json, "StoreId");
		}
	}
	
	
	
	public class GetStoreItemsResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of store items
		/// </summary>
		
		public List<StoreItem> Store { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("Store", Store);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Store = JsonUtil.GetObjectList<StoreItem>(json, "Store");
		}
	}
	
	
	
	public class GetTitleDataRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		///  array of keys to get back data from the TitleData data blob, set by the admin tools
		/// </summary>
		
		public List<string> Keys { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("Keys", Keys);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Keys = JsonUtil.GetList<string>(json, "Keys");
		}
	}
	
	
	
	public class GetTitleDataResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// a dictionary object of key / value pairs
		/// </summary>
		
		public Dictionary<string,string> Data { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("Data", Data);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Data = JsonUtil.GetDictionary<string>(json, "Data");
		}
	}
	
	
	
	public class GetTitleNewsRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// limits the results to the last n entries (defaults to 10 if not set)
		/// </summary>
		
		public int? Count { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("Count", Count);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Count = (int?)JsonUtil.Get<double?>(json, "Count");
		}
	}
	
	
	
	public class GetTitleNewsResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of news items
		/// </summary>
		
		public List<TitleNewsItem> News { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("News", News);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			News = JsonUtil.GetObjectList<TitleNewsItem>(json, "News");
		}
	}
	
	
	
	public class GetUserCombinedInfoRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFabId of the user to load info about. Defaults to yourself if not set.
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// If set to false, account info will not be returned (defaults to true)
		/// </summary>
		
		public bool? GetAccountInfo { get; set;}
		
		/// <summary>
		/// If set to false, inventory will not be returned (defaults to true). Inventory will never be returned for users other than yourself.
		/// </summary>
		
		public bool? GetInventory { get; set;}
		
		/// <summary>
		/// If set to false, virtual currency balances will not be returned (defaults to true). Currency balances will never be returned for users other than yourself.
		/// </summary>
		
		public bool? GetVirtualCurrency { get; set;}
		
		/// <summary>
		/// If set to false, custom user data will not be returned (defaults to true).
		/// </summary>
		
		public bool? GetUserData { get; set;}
		
		/// <summary>
		/// User custom data keys to return. Leave null to get all keys. For users other than yourself, only public data will be returned.
		/// </summary>
		
		public List<string> UserDataKeys { get; set;}
		
		/// <summary>
		/// If set to false, read-only user data will not be returned (defaults to true).
		/// </summary>
		
		public bool? GetReadOnlyData { get; set;}
		
		/// <summary>
		/// User read-only custom data keys to return. Leave null to get all keys. For users other than yourself, only public data will be returned.
		/// </summary>
		
		public List<string> ReadOnlyDataKeys { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("PlayFabId", PlayFabId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("GetAccountInfo", GetAccountInfo);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("GetInventory", GetInventory);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("GetVirtualCurrency", GetVirtualCurrency);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("GetUserData", GetUserData);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("UserDataKeys", UserDataKeys);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("GetReadOnlyData", GetReadOnlyData);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("ReadOnlyDataKeys", ReadOnlyDataKeys);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			GetAccountInfo = (bool?)JsonUtil.Get<bool?>(json, "GetAccountInfo");
			GetInventory = (bool?)JsonUtil.Get<bool?>(json, "GetInventory");
			GetVirtualCurrency = (bool?)JsonUtil.Get<bool?>(json, "GetVirtualCurrency");
			GetUserData = (bool?)JsonUtil.Get<bool?>(json, "GetUserData");
			UserDataKeys = JsonUtil.GetList<string>(json, "UserDataKeys");
			GetReadOnlyData = (bool?)JsonUtil.Get<bool?>(json, "GetReadOnlyData");
			ReadOnlyDataKeys = JsonUtil.GetList<string>(json, "ReadOnlyDataKeys");
		}
	}
	
	
	
	public class GetUserCombinedInfoResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFabId of the owner of the combined info
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// account information for the user
		/// </summary>
		
		public UserAccountInfo AccountInfo { get; set;}
		
		/// <summary>
		/// array of inventory items in the user's current inventory
		/// </summary>
		
		public List<ItemInstance> Inventory { get; set;}
		
		/// <summary>
		/// array of virtual currency balance(s) belonging to the user
		/// </summary>
		
		public Dictionary<string,int> VirtualCurrency { get; set;}
		
		/// <summary>
		/// user specific custom data
		/// </summary>
		
		public Dictionary<string,UserDataRecord> Data { get; set;}
		
		/// <summary>
		/// user specific read-only data
		/// </summary>
		
		public Dictionary<string,UserDataRecord> ReadOnlyData { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("PlayFabId", PlayFabId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("AccountInfo", AccountInfo);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Inventory", Inventory);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("VirtualCurrency", VirtualCurrency);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Data", Data);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("ReadOnlyData", ReadOnlyData);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			AccountInfo = JsonUtil.GetObject<UserAccountInfo>(json, "AccountInfo");
			Inventory = JsonUtil.GetObjectList<ItemInstance>(json, "Inventory");
			VirtualCurrency = JsonUtil.GetDictionaryInt32(json, "VirtualCurrency");
			Data = JsonUtil.GetObjectDictionary<UserDataRecord>(json, "Data");
			ReadOnlyData = JsonUtil.GetObjectDictionary<UserDataRecord>(json, "ReadOnlyData");
		}
	}
	
	
	
	public class GetUserDataRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// specific keys to search for in the custom user data. Leave null to get all keys.
		/// </summary>
		
		public List<string> Keys { get; set;}
		
		/// <summary>
		/// PlayFabId of the user to load data for. Optional, defaults to yourself if not set.
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("Keys", Keys);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("PlayFabId", PlayFabId);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Keys = JsonUtil.GetList<string>(json, "Keys");
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
		}
	}
	
	
	
	public class GetUserDataResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// user specific data for this title
		/// </summary>
		
		public Dictionary<string,UserDataRecord> Data { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("Data", Data);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Data = JsonUtil.GetObjectDictionary<UserDataRecord>(json, "Data");
		}
	}
	
	
	
	public class GetUserInventoryRequest : PlayFabModelBase
	{
		
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class GetUserInventoryResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// array of inventory items in the user's current inventory
		/// </summary>
		
		public List<ItemInstance> Inventory { get; set;}
		
		/// <summary>
		/// array of virtual currency balance(s) belonging to the user
		/// </summary>
		
		public Dictionary<string,int> VirtualCurrency { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("Inventory", Inventory);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("VirtualCurrency", VirtualCurrency);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Inventory = JsonUtil.GetObjectList<ItemInstance>(json, "Inventory");
			VirtualCurrency = JsonUtil.GetDictionaryInt32(json, "VirtualCurrency");
		}
	}
	
	
	
	public class GetUserStatisticsRequest : PlayFabModelBase
	{
		
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class GetUserStatisticsResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// user statistics for the active title
		/// </summary>
		
		public Dictionary<string,int> UserStatistics { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("UserStatistics", UserStatistics);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			UserStatistics = JsonUtil.GetDictionaryInt32(json, "UserStatistics");
		}
	}
	
	
	
	/// <summary>
	/// A unique instance of an item in a user's inventory
	/// </summary>
	public class ItemInstance : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the inventory item, as defined in the catalog
		/// </summary>
		
		public string ItemId { get; set;}
		
		/// <summary>
		/// unique item identifier for this specific instance of the item
		/// </summary>
		
		public string ItemInstanceId { get; set;}
		
		/// <summary>
		/// class name for the inventory item, as defined in the catalog
		/// </summary>
		
		public string ItemClass { get; set;}
		
		/// <summary>
		/// timestamp for when this instance was purchased
		/// </summary>
		
		public DateTime? PurchaseDate { get; set;}
		
		/// <summary>
		/// timestamp for when this instance will expire
		/// </summary>
		
		public DateTime? Expiration { get; set;}
		
		/// <summary>
		/// total number of remaining uses, if this is a consumable item
		/// </summary>
		
		public int? RemainingUses { get; set;}
		
		/// <summary>
		/// game specific comment associated with this instance when it was added to the user inventory
		/// </summary>
		
		public string Annotation { get; set;}
		
		/// <summary>
		/// catalog version for the inventory item, when this instance was created
		/// </summary>
		
		public string CatalogVersion { get; set;}
		
		/// <summary>
		/// unique identifier for the parent inventory item, as defined in the catalog, for object which were added from a bundle or container
		/// </summary>
		
		public string BundleParent { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("ItemId", ItemId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("ItemInstanceId", ItemInstanceId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("ItemClass", ItemClass);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("PurchaseDate", PurchaseDate);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Expiration", Expiration);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("RemainingUses", RemainingUses);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Annotation", Annotation);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("CatalogVersion", CatalogVersion);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("BundleParent", BundleParent);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ItemId = (string)JsonUtil.Get<string>(json, "ItemId");
			ItemInstanceId = (string)JsonUtil.Get<string>(json, "ItemInstanceId");
			ItemClass = (string)JsonUtil.Get<string>(json, "ItemClass");
			PurchaseDate = (DateTime?)JsonUtil.GetDateTime(json, "PurchaseDate");
			Expiration = (DateTime?)JsonUtil.GetDateTime(json, "Expiration");
			RemainingUses = (int?)JsonUtil.Get<double?>(json, "RemainingUses");
			Annotation = (string)JsonUtil.Get<string>(json, "Annotation");
			CatalogVersion = (string)JsonUtil.Get<string>(json, "CatalogVersion");
			BundleParent = (string)JsonUtil.Get<string>(json, "BundleParent");
		}
	}
	
	
	
	public class ItemPuchaseRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique ItemId of the item to purchase
		/// </summary>
		
		public string ItemId { get; set;}
		
		/// <summary>
		/// how many of this item to purchase
		/// </summary>
		
		public uint Quantity { get; set;}
		
		/// <summary>
		/// title-specific text concerning this purchase
		/// </summary>
		
		public string Annotation { get; set;}
		
		/// <summary>
		/// items to be upgraded as a result of this purchase (upgraded items are hidden, as they are "replaced" by the new items)
		/// </summary>
		
		public List<string> UpgradeFromItems { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("ItemId", ItemId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Quantity", Quantity);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Annotation", Annotation);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("UpgradeFromItems", UpgradeFromItems);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ItemId = (string)JsonUtil.Get<string>(json, "ItemId");
			Quantity = (uint)JsonUtil.Get<double?>(json, "Quantity");
			Annotation = (string)JsonUtil.Get<string>(json, "Annotation");
			UpgradeFromItems = JsonUtil.GetList<string>(json, "UpgradeFromItems");
		}
	}
	
	
	
	public class LinkAndroidDeviceIDRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// Android device identifier for the user's device
		/// </summary>
		
		public string AndroidDeviceId { get; set;}
		
		/// <summary>
		/// specific Operating System version for the user's device
		/// </summary>
		
		public string OS { get; set;}
		
		/// <summary>
		/// specific model of the user's device
		/// </summary>
		
		public string AndroidDevice { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("AndroidDeviceId", AndroidDeviceId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("OS", OS);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("AndroidDevice", AndroidDevice);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			AndroidDeviceId = (string)JsonUtil.Get<string>(json, "AndroidDeviceId");
			OS = (string)JsonUtil.Get<string>(json, "OS");
			AndroidDevice = (string)JsonUtil.Get<string>(json, "AndroidDevice");
		}
	}
	
	
	
	public class LinkAndroidDeviceIDResult : PlayFabModelBase
	{
		
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class LinkFacebookAccountRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier from Facebook for the user
		/// </summary>
		
		public string AccessToken { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("AccessToken", AccessToken);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			AccessToken = (string)JsonUtil.Get<string>(json, "AccessToken");
		}
	}
	
	
	
	public class LinkFacebookAccountResult : PlayFabModelBase
	{
		
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class LinkGameCenterAccountRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// Game Center identifier for the player account to be linked
		/// </summary>
		
		public string GameCenterId { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("GameCenterId", GameCenterId);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			GameCenterId = (string)JsonUtil.Get<string>(json, "GameCenterId");
		}
	}
	
	
	
	public class LinkGameCenterAccountResult : PlayFabModelBase
	{
		
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class LinkIOSDeviceIDRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// vendor-specific iOS identifier for the user's device
		/// </summary>
		
		public string DeviceId { get; set;}
		
		/// <summary>
		/// specific Operating System version for the user's device
		/// </summary>
		
		public string OS { get; set;}
		
		/// <summary>
		/// specific model of the user's device
		/// </summary>
		
		public string DeviceModel { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("DeviceId", DeviceId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("OS", OS);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("DeviceModel", DeviceModel);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			DeviceId = (string)JsonUtil.Get<string>(json, "DeviceId");
			OS = (string)JsonUtil.Get<string>(json, "OS");
			DeviceModel = (string)JsonUtil.Get<string>(json, "DeviceModel");
		}
	}
	
	
	
	public class LinkIOSDeviceIDResult : PlayFabModelBase
	{
		
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class LinkSteamAccountRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// authentication token for the user, returned as a byte array from Steam, and converted to a string (for example, the byte 0x08 should become "08")
		/// </summary>
		
		public string SteamTicket { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("SteamTicket", SteamTicket);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			SteamTicket = (string)JsonUtil.Get<string>(json, "SteamTicket");
		}
	}
	
	
	
	public class LinkSteamAccountResult : PlayFabModelBase
	{
		
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class LogEventRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// A unique event name which will be used as the table name in the Redshift database. The name will be made lower case, and cannot not contain spaces. The use of underscores is recommended, for readability. Events also cannot match reserved terms. The PlayFab reserved terms are 'log_in' and 'purchase', 'create' and 'request', while the Redshift reserved terms can be found here: http://docs.aws.amazon.com/redshift/latest/dg/r_pg_keywords.html.
		/// </summary>
		
		public string eventName { get; set;}
		
		/// <summary>
		/// Contains all the data for this event. Event Values can be strings, booleans or numerics (float, double, integer, long) and must be consistent on a per-event basis (if the Value for Key 'A' in Event 'Foo' is an integer the first time it is sent, it must be an integer in all subsequent 'Foo' events). As with event names, Keys must also not use reserved words (see above). Finally, the size of the Body for an event must be less than 32KB (UTF-8 format).
		/// </summary>
		
		public Dictionary<string,object> Body { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("eventName", eventName);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Body", Body);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			eventName = (string)JsonUtil.Get<string>(json, "eventName");
			Body = JsonUtil.GetDictionary<object>(json, "Body");
		}
	}
	
	
	
	public class LogEventResult : PlayFabModelBase
	{
		
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class LoginResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// a unique token authorizing the user and game at the server level, for the current session
		/// </summary>
		
		public string SessionTicket { get; set;}
		
		/// <summary>
		/// player's unique PlayFabId
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// true if the account was newly created on this login
		/// </summary>
		
		public bool NewlyCreated { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("SessionTicket", SessionTicket);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("PlayFabId", PlayFabId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("NewlyCreated", NewlyCreated);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			SessionTicket = (string)JsonUtil.Get<string>(json, "SessionTicket");
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			NewlyCreated = (bool)JsonUtil.Get<bool?>(json, "NewlyCreated");
		}
	}
	
	
	
	public class LoginWithAndroidDeviceIDRequest : PlayFabModelBase
	{
		
		
		
		public string TitleId { get; set;}
		
		/// <summary>
		/// Android device identifier for the user's device
		/// </summary>
		
		public string AndroidDeviceId { get; set;}
		
		/// <summary>
		/// specific Operating System version for the user's device
		/// </summary>
		
		public string OS { get; set;}
		
		/// <summary>
		/// specific model of the user's device
		/// </summary>
		
		public string AndroidDevice { get; set;}
		
		/// <summary>
		/// automatically create a PlayFab account if one is not currently linked to this iOS device
		/// </summary>
		
		public bool? CreateAccount { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("TitleId", TitleId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("AndroidDeviceId", AndroidDeviceId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("OS", OS);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("AndroidDevice", AndroidDevice);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("CreateAccount", CreateAccount);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
			AndroidDeviceId = (string)JsonUtil.Get<string>(json, "AndroidDeviceId");
			OS = (string)JsonUtil.Get<string>(json, "OS");
			AndroidDevice = (string)JsonUtil.Get<string>(json, "AndroidDevice");
			CreateAccount = (bool?)JsonUtil.Get<bool?>(json, "CreateAccount");
		}
	}
	
	
	
	public class LoginWithFacebookRequest : PlayFabModelBase
	{
		
		
		
		public string TitleId { get; set;}
		
		/// <summary>
		/// unique identifier from Facebook for the user
		/// </summary>
		
		public string AccessToken { get; set;}
		
		/// <summary>
		/// automatically create a PlayFab account if one is not currently linked to this Facebook account
		/// </summary>
		
		public bool? CreateAccount { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("TitleId", TitleId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("AccessToken", AccessToken);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("CreateAccount", CreateAccount);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
			AccessToken = (string)JsonUtil.Get<string>(json, "AccessToken");
			CreateAccount = (bool?)JsonUtil.Get<bool?>(json, "CreateAccount");
		}
	}
	
	
	
	public class LoginWithGameCenterRequest : PlayFabModelBase
	{
		
		
		
		public string TitleId { get; set;}
		
		/// <summary>
		/// unique Game Center player id
		/// </summary>
		
		public string PlayerId { get; set;}
		
		/// <summary>
		/// automatically create a PlayFab account if one is not currently linked to this Game Center id
		/// </summary>
		
		public bool? CreateAccount { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("TitleId", TitleId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("PlayerId", PlayerId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("CreateAccount", CreateAccount);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
			PlayerId = (string)JsonUtil.Get<string>(json, "PlayerId");
			CreateAccount = (bool?)JsonUtil.Get<bool?>(json, "CreateAccount");
		}
	}
	
	
	
	public class LoginWithGoogleAccountRequest : PlayFabModelBase
	{
		
		
		
		public string TitleId { get; set;}
		
		/// <summary>
		/// unique token from Google Play for the user
		/// </summary>
		
		public string AccessToken { get; set;}
		
		/// <summary>
		/// automatically create a PlayFab account if one is not currently linked to this Google account
		/// </summary>
		
		public bool? CreateAccount { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("TitleId", TitleId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("AccessToken", AccessToken);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("CreateAccount", CreateAccount);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
			AccessToken = (string)JsonUtil.Get<string>(json, "AccessToken");
			CreateAccount = (bool?)JsonUtil.Get<bool?>(json, "CreateAccount");
		}
	}
	
	
	
	public class LoginWithIOSDeviceIDRequest : PlayFabModelBase
	{
		
		
		
		public string TitleId { get; set;}
		
		/// <summary>
		/// vendor-specific iOS identifier for the user's device
		/// </summary>
		
		public string DeviceId { get; set;}
		
		/// <summary>
		/// specific Operating System version for the user's device
		/// </summary>
		
		public string OS { get; set;}
		
		/// <summary>
		/// specific model of the user's device
		/// </summary>
		
		public string DeviceModel { get; set;}
		
		/// <summary>
		/// automatically create a PlayFab account if one is not currently linked to this iOS device
		/// </summary>
		
		public bool? CreateAccount { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("TitleId", TitleId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("DeviceId", DeviceId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("OS", OS);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("DeviceModel", DeviceModel);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("CreateAccount", CreateAccount);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
			DeviceId = (string)JsonUtil.Get<string>(json, "DeviceId");
			OS = (string)JsonUtil.Get<string>(json, "OS");
			DeviceModel = (string)JsonUtil.Get<string>(json, "DeviceModel");
			CreateAccount = (bool?)JsonUtil.Get<bool?>(json, "CreateAccount");
		}
	}
	
	
	
	public class LoginWithPlayFabRequest : PlayFabModelBase
	{
		
		
		
		public string TitleId { get; set;}
		
		/// <summary>
		/// PlayFab username for the account (3-24 characters)
		/// </summary>
		
		public string Username { get; set;}
		
		
		public string Password { get; set;}
		
		
		public string PublisherId { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("TitleId", TitleId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Username", Username);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Password", Password);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("PublisherId", PublisherId);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
			Username = (string)JsonUtil.Get<string>(json, "Username");
			Password = (string)JsonUtil.Get<string>(json, "Password");
			PublisherId = (string)JsonUtil.Get<string>(json, "PublisherId");
		}
	}
	
	
	
	public class LoginWithSteamRequest : PlayFabModelBase
	{
		
		
		
		public string TitleId { get; set;}
		
		/// <summary>
		/// authentication token for the user, returned as a byte array from Steam, and converted to a string (for example, the byte 0x08 should become "08")
		/// </summary>
		
		public string SteamTicket { get; set;}
		
		/// <summary>
		/// automatically create a PlayFab account if one is not currently linked to this Steam account
		/// </summary>
		
		public bool? CreateAccount { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("TitleId", TitleId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("SteamTicket", SteamTicket);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("CreateAccount", CreateAccount);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
			SteamTicket = (string)JsonUtil.Get<string>(json, "SteamTicket");
			CreateAccount = (bool?)JsonUtil.Get<bool?>(json, "CreateAccount");
		}
	}
	
	
	
	public class MatchmakeRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// build version to match against
		/// </summary>
		
		public string BuildVersion { get; set;}
		
		/// <summary>
		/// region to match make against
		/// </summary>
		
		public Region? Region { get; set;}
		
		/// <summary>
		/// game mode to match make against
		/// </summary>
		
		public string GameMode { get; set;}
		
		/// <summary>
		/// lobby identifier to match make against (used to select a specific server)
		/// </summary>
		
		public string LobbyId { get; set;}
		
		/// <summary>
		/// [deprecated]
		/// </summary>
		
		public bool? EnableQueue { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("BuildVersion", BuildVersion);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Region", Region);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("GameMode", GameMode);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("LobbyId", LobbyId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("EnableQueue", EnableQueue);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			BuildVersion = (string)JsonUtil.Get<string>(json, "BuildVersion");
			Region = (Region?)JsonUtil.GetEnum<Region>(json, "Region");
			GameMode = (string)JsonUtil.Get<string>(json, "GameMode");
			LobbyId = (string)JsonUtil.Get<string>(json, "LobbyId");
			EnableQueue = (bool?)JsonUtil.Get<bool?>(json, "EnableQueue");
		}
	}
	
	
	
	public class MatchmakeResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique lobby identifier of the server matched
		/// </summary>
		
		public string LobbyID { get; set;}
		
		/// <summary>
		/// IP address of the server
		/// </summary>
		
		public string ServerHostname { get; set;}
		
		/// <summary>
		/// port number to use for non-http communications with the server
		/// </summary>
		
		public int? ServerPort { get; set;}
		
		/// <summary>
		/// server authorization ticket (used by RedeemCoupon to validate user insertion into the game)
		/// </summary>
		
		public string Ticket { get; set;}
		
		/// <summary>
		/// timestamp for when the server will expire, if applicable
		/// </summary>
		
		public string Expires { get; set;}
		
		/// <summary>
		/// time in milliseconds the application is configured to wait on matchmaking results
		/// </summary>
		
		public int? PollWaitTimeMS { get; set;}
		
		/// <summary>
		/// result of match making process
		/// </summary>
		
		public MatchmakeStatus? Status { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("LobbyID", LobbyID);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("ServerHostname", ServerHostname);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("ServerPort", ServerPort);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Ticket", Ticket);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Expires", Expires);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("PollWaitTimeMS", PollWaitTimeMS);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Status", Status);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			LobbyID = (string)JsonUtil.Get<string>(json, "LobbyID");
			ServerHostname = (string)JsonUtil.Get<string>(json, "ServerHostname");
			ServerPort = (int?)JsonUtil.Get<double?>(json, "ServerPort");
			Ticket = (string)JsonUtil.Get<string>(json, "Ticket");
			Expires = (string)JsonUtil.Get<string>(json, "Expires");
			PollWaitTimeMS = (int?)JsonUtil.Get<double?>(json, "PollWaitTimeMS");
			Status = (MatchmakeStatus?)JsonUtil.GetEnum<MatchmakeStatus>(json, "Status");
		}
	}
	
	
	
	public enum MatchmakeStatus
	{
		Complete,
		Waiting,
		GameNotFound
	}
	
	
	
	public class ModifyUserVirtualCurrencyResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// name of the virtual currency which was modified
		/// </summary>
		
		public string VirtualCurrency { get; set;}
		
		/// <summary>
		/// balance of the virtual currency after modification
		/// </summary>
		
		public int Balance { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("VirtualCurrency", VirtualCurrency);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Balance", Balance);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			VirtualCurrency = (string)JsonUtil.Get<string>(json, "VirtualCurrency");
			Balance = (int)JsonUtil.Get<double?>(json, "Balance");
		}
	}
	
	
	
	public class PayForPurchaseRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// purchase order identifier returned from StartPurchase
		/// </summary>
		
		public string OrderId { get; set;}
		
		/// <summary>
		/// payment provider to use to fund the purchase
		/// </summary>
		
		public string ProviderName { get; set;}
		
		/// <summary>
		/// currency to use to fund the purchase
		/// </summary>
		
		public string Currency { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("OrderId", OrderId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("ProviderName", ProviderName);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Currency", Currency);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			OrderId = (string)JsonUtil.Get<string>(json, "OrderId");
			ProviderName = (string)JsonUtil.Get<string>(json, "ProviderName");
			Currency = (string)JsonUtil.Get<string>(json, "Currency");
		}
	}
	
	
	
	public class PayForPurchaseResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// purchase order identifier
		/// </summary>
		
		public string OrderId { get; set;}
		
		/// <summary>
		/// status of the transaction
		/// </summary>
		
		public TransactionStatus? Status { get; set;}
		
		/// <summary>
		/// virtual currency cost of the transaction
		/// </summary>
		
		public Dictionary<string,int> VCAmount { get; set;}
		
		/// <summary>
		/// real world currency for the transaction
		/// </summary>
		
		public string PurchaseCurrency { get; set;}
		
		/// <summary>
		/// real world cost of the transaction
		/// </summary>
		
		public uint PurchasePrice { get; set;}
		
		/// <summary>
		/// local credit applied to the transaction (provider specific)
		/// </summary>
		
		public uint CreditApplied { get; set;}
		
		/// <summary>
		/// provider used for the transaction
		/// </summary>
		
		public string ProviderData { get; set;}
		
		/// <summary>
		/// url to the purchase provider page that details the purchase
		/// </summary>
		
		public string PurchaseConfirmationPageURL { get; set;}
		
		/// <summary>
		/// current virtual currency totals for the user
		/// </summary>
		
		public Dictionary<string,int> VirtualCurrency { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("OrderId", OrderId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Status", Status);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("VCAmount", VCAmount);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("PurchaseCurrency", PurchaseCurrency);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("PurchasePrice", PurchasePrice);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("CreditApplied", CreditApplied);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("ProviderData", ProviderData);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("PurchaseConfirmationPageURL", PurchaseConfirmationPageURL);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("VirtualCurrency", VirtualCurrency);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			OrderId = (string)JsonUtil.Get<string>(json, "OrderId");
			Status = (TransactionStatus?)JsonUtil.GetEnum<TransactionStatus>(json, "Status");
			VCAmount = JsonUtil.GetDictionaryInt32(json, "VCAmount");
			PurchaseCurrency = (string)JsonUtil.Get<string>(json, "PurchaseCurrency");
			PurchasePrice = (uint)JsonUtil.Get<double?>(json, "PurchasePrice");
			CreditApplied = (uint)JsonUtil.Get<double?>(json, "CreditApplied");
			ProviderData = (string)JsonUtil.Get<string>(json, "ProviderData");
			PurchaseConfirmationPageURL = (string)JsonUtil.Get<string>(json, "PurchaseConfirmationPageURL");
			VirtualCurrency = JsonUtil.GetDictionaryInt32(json, "VirtualCurrency");
		}
	}
	
	
	
	public class PaymentOption : PlayFabModelBase
	{
		
		
		/// <summary>
		/// specific currency to use to fund the purchase
		/// </summary>
		
		public string Currency { get; set;}
		
		/// <summary>
		/// name of the purchase provider for this option
		/// </summary>
		
		public string ProviderName { get; set;}
		
		/// <summary>
		/// amount of the specified currency needed for the purchase
		/// </summary>
		
		public uint Price { get; set;}
		
		/// <summary>
		/// amount of existing credit the user has with the provider
		/// </summary>
		
		public uint StoreCredit { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("Currency", Currency);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("ProviderName", ProviderName);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Price", Price);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("StoreCredit", StoreCredit);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Currency = (string)JsonUtil.Get<string>(json, "Currency");
			ProviderName = (string)JsonUtil.Get<string>(json, "ProviderName");
			Price = (uint)JsonUtil.Get<double?>(json, "Price");
			StoreCredit = (uint)JsonUtil.Get<double?>(json, "StoreCredit");
		}
	}
	
	
	
	public class PlayerLeaderboardEntry : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier of the user for this leaderboard entry
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// title-specific display name of the user for this leaderboard entry
		/// </summary>
		
		public string DisplayName { get; set;}
		
		/// <summary>
		/// specific value of the user's statistic
		/// </summary>
		
		public int StatValue { get; set;}
		
		/// <summary>
		/// user's overall position in the leaderboard
		/// </summary>
		
		public int Position { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("PlayFabId", PlayFabId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("DisplayName", DisplayName);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("StatValue", StatValue);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Position", Position);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			DisplayName = (string)JsonUtil.Get<string>(json, "DisplayName");
			StatValue = (int)JsonUtil.Get<double?>(json, "StatValue");
			Position = (int)JsonUtil.Get<double?>(json, "Position");
		}
	}
	
	
	
	public class PurchasedItem : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique instance identifier for this catalog item
		/// </summary>
		
		public string ItemInstanceId { get; set;}
		
		/// <summary>
		/// unique identifier for the catalog item
		/// </summary>
		
		public string ItemId { get; set;}
		
		/// <summary>
		/// catalog version for the item purchased
		/// </summary>
		
		public string CatalogVersion { get; set;}
		
		/// <summary>
		/// display name for the catalog item
		/// </summary>
		
		public string DisplayName { get; set;}
		
		/// <summary>
		/// currency type for the cost of the catalog item
		/// </summary>
		
		public string UnitCurrency { get; set;}
		
		/// <summary>
		/// cost of the catalog item in the given currency
		/// </summary>
		
		public uint UnitPrice { get; set;}
		
		/// <summary>
		/// array of unique items that were awarded when this catalog item was purchased
		/// </summary>
		
		public List<string> BundleContents { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("ItemInstanceId", ItemInstanceId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("ItemId", ItemId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("CatalogVersion", CatalogVersion);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("DisplayName", DisplayName);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("UnitCurrency", UnitCurrency);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("UnitPrice", UnitPrice);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("BundleContents", BundleContents);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ItemInstanceId = (string)JsonUtil.Get<string>(json, "ItemInstanceId");
			ItemId = (string)JsonUtil.Get<string>(json, "ItemId");
			CatalogVersion = (string)JsonUtil.Get<string>(json, "CatalogVersion");
			DisplayName = (string)JsonUtil.Get<string>(json, "DisplayName");
			UnitCurrency = (string)JsonUtil.Get<string>(json, "UnitCurrency");
			UnitPrice = (uint)JsonUtil.Get<double?>(json, "UnitPrice");
			BundleContents = JsonUtil.GetList<string>(json, "BundleContents");
		}
	}
	
	
	
	public class PurchaseItemRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique ItemId of the item to purchase
		/// </summary>
		
		public string ItemId { get; set;}
		
		/// <summary>
		/// virtual currency to use to purchase the item
		/// </summary>
		
		public string VirtualCurrency { get; set;}
		
		/// <summary>
		/// price the client expects to pay for the item (in case a new catalog or store was uploaded, with new prices)
		/// </summary>
		
		public int Price { get; set;}
		
		/// <summary>
		/// catalog version for the items to be purchased (defaults to most recent version
		/// </summary>
		
		public string CatalogVersion { get; set;}
		
		/// <summary>
		/// store to buy this item through. If not set, prices default to those in the catalog.
		/// </summary>
		
		public string StoreId { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("ItemId", ItemId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("VirtualCurrency", VirtualCurrency);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Price", Price);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("CatalogVersion", CatalogVersion);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("StoreId", StoreId);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ItemId = (string)JsonUtil.Get<string>(json, "ItemId");
			VirtualCurrency = (string)JsonUtil.Get<string>(json, "VirtualCurrency");
			Price = (int)JsonUtil.Get<double?>(json, "Price");
			CatalogVersion = (string)JsonUtil.Get<string>(json, "CatalogVersion");
			StoreId = (string)JsonUtil.Get<string>(json, "StoreId");
		}
	}
	
	
	
	public class PurchaseItemResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// details for the items purchased
		/// </summary>
		
		public List<PurchasedItem> Items { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("Items", Items);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Items = JsonUtil.GetObjectList<PurchasedItem>(json, "Items");
		}
	}
	
	
	
	public class RedeemCouponRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// generated coupon code to redeem
		/// </summary>
		
		public string CouponCode { get; set;}
		
		/// <summary>
		/// catalog version of the coupon
		/// </summary>
		
		public string CatalogVersion { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("CouponCode", CouponCode);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("CatalogVersion", CatalogVersion);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			CouponCode = (string)JsonUtil.Get<string>(json, "CouponCode");
			CatalogVersion = (string)JsonUtil.Get<string>(json, "CatalogVersion");
		}
	}
	
	
	
	public class RedeemCouponResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// items granted to the player as a result of redeeming the coupon
		/// </summary>
		
		public List<ItemInstance> GrantedItems { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("GrantedItems", GrantedItems);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			GrantedItems = JsonUtil.GetObjectList<ItemInstance>(json, "GrantedItems");
		}
	}
	
	
	
	public class RefreshPSNAuthTokenRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// Auth code returned by PSN OAuth system
		/// </summary>
		
		public string AuthCode { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("AuthCode", AuthCode);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			AuthCode = (string)JsonUtil.Get<string>(json, "AuthCode");
		}
	}
	
	
	
	public enum Region
	{
		USCentral,
		USEast,
		EUWest,
		Singapore,
		Japan,
		Brazil,
		Australia
	}
	
	
	
	public class RegionInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the region
		/// </summary>
		
		public Region? Region { get; set;}
		
		/// <summary>
		/// name of the region
		/// </summary>
		
		public string Name { get; set;}
		
		/// <summary>
		/// indicates whether the server specified is available in this region
		/// </summary>
		
		public bool Available { get; set;}
		
		/// <summary>
		/// url to ping to get roundtrip time
		/// </summary>
		
		public string PingUrl { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("Region", Region);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Name", Name);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Available", Available);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("PingUrl", PingUrl);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Region = (Region?)JsonUtil.GetEnum<Region>(json, "Region");
			Name = (string)JsonUtil.Get<string>(json, "Name");
			Available = (bool)JsonUtil.Get<bool?>(json, "Available");
			PingUrl = (string)JsonUtil.Get<string>(json, "PingUrl");
		}
	}
	
	
	
	public class RegisterForIOSPushNotificationRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique token generated by the Apple Push Notification service when the title registered to receive push notifications
		/// </summary>
		
		public string DeviceToken { get; set;}
		
		/// <summary>
		/// If true, send a test push message immediately after sucessful registration. Defaults to false.
		/// </summary>
		
		public bool? SendPushNotificationConfirmation { get; set;}
		
		/// <summary>
		/// Message to display when confirming push notification.
		/// </summary>
		
		public string ConfirmationMessage { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("DeviceToken", DeviceToken);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("SendPushNotificationConfirmation", SendPushNotificationConfirmation);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("ConfirmationMessage", ConfirmationMessage);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			DeviceToken = (string)JsonUtil.Get<string>(json, "DeviceToken");
			SendPushNotificationConfirmation = (bool?)JsonUtil.Get<bool?>(json, "SendPushNotificationConfirmation");
			ConfirmationMessage = (string)JsonUtil.Get<string>(json, "ConfirmationMessage");
		}
	}
	
	
	
	public class RegisterForIOSPushNotificationResult : PlayFabModelBase
	{
		
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class RegisterPlayFabUserRequest : PlayFabModelBase
	{
		
		
		
		public string TitleId { get; set;}
		
		
		public string Username { get; set;}
		
		
		public string Email { get; set;}
		
		
		public string Password { get; set;}
		
		/// <summary>
		/// optional string indicating where this user came from (iOS iPhone, Android, etc.)
		/// </summary>
		
		public string Origination { get; set;}
		
		
		public string PublisherId { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("TitleId", TitleId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Username", Username);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Email", Email);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Password", Password);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Origination", Origination);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("PublisherId", PublisherId);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
			Username = (string)JsonUtil.Get<string>(json, "Username");
			Email = (string)JsonUtil.Get<string>(json, "Email");
			Password = (string)JsonUtil.Get<string>(json, "Password");
			Origination = (string)JsonUtil.Get<string>(json, "Origination");
			PublisherId = (string)JsonUtil.Get<string>(json, "PublisherId");
		}
	}
	
	
	
	public class RegisterPlayFabUserResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab unique identifier for this newly created account
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// a unique token identifying the user and game at the server level, for the current session
		/// </summary>
		
		public string SessionTicket { get; set;}
		
		/// <summary>
		/// PlayFab unique user name
		/// </summary>
		
		public string Username { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("PlayFabId", PlayFabId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("SessionTicket", SessionTicket);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Username", Username);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			SessionTicket = (string)JsonUtil.Get<string>(json, "SessionTicket");
			Username = (string)JsonUtil.Get<string>(json, "Username");
		}
	}
	
	
	
	public class RemoveFriendRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab identifier of the friend account which is to be removed
		/// </summary>
		
		public string FriendPlayFabId { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("FriendPlayFabId", FriendPlayFabId);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			FriendPlayFabId = (string)JsonUtil.Get<string>(json, "FriendPlayFabId");
		}
	}
	
	
	
	public class RemoveFriendResult : PlayFabModelBase
	{
		
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class RemoveSharedGroupMembersRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the shared group
		/// </summary>
		
		public string SharedGroupId { get; set;}
		
		/// <summary>
		/// list of PlayFabId identifiers of users to remove from the shared group
		/// </summary>
		
		public List<string> PlayFabIds { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("SharedGroupId", SharedGroupId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("PlayFabIds", PlayFabIds);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			SharedGroupId = (string)JsonUtil.Get<string>(json, "SharedGroupId");
			PlayFabIds = JsonUtil.GetList<string>(json, "PlayFabIds");
		}
	}
	
	
	
	public class RemoveSharedGroupMembersResult : PlayFabModelBase
	{
		
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class ReportPlayerClientRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFabId of the reported player
		/// </summary>
		
		public string ReporteeId { get; set;}
		
		/// <summary>
		/// title player was reported in, optional if report not for specific title
		/// </summary>
		
		public string TitleId { get; set;}
		
		/// <summary>
		/// Optional additional comment by reporting player
		/// </summary>
		
		public string Comment { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("ReporteeId", ReporteeId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("TitleId", TitleId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Comment", Comment);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ReporteeId = (string)JsonUtil.Get<string>(json, "ReporteeId");
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
			Comment = (string)JsonUtil.Get<string>(json, "Comment");
		}
	}
	
	
	
	public class ReportPlayerClientResult : PlayFabModelBase
	{
		
		
		
		public bool Updated { get; set;}
		
		
		public int SubmissionsRemaining { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("Updated", Updated);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("SubmissionsRemaining", SubmissionsRemaining);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Updated = (bool)JsonUtil.Get<bool?>(json, "Updated");
			SubmissionsRemaining = (int)JsonUtil.Get<double?>(json, "SubmissionsRemaining");
		}
	}
	
	
	
	public class RestoreIOSPurchasesRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// base64 encoded receipt data, passed back by the App Store as a result of a successful purchase
		/// </summary>
		
		public string ReceiptData { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("ReceiptData", ReceiptData);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ReceiptData = (string)JsonUtil.Get<string>(json, "ReceiptData");
		}
	}
	
	
	
	public class RestoreIOSPurchasesResult : PlayFabModelBase
	{
		
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class RunCloudScriptRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// server action to trigger
		/// </summary>
		
		public string ActionId { get; set;}
		
		/// <summary>
		/// parameters to pass into the action (If you use this, don't use ParamsEncoded)
		/// </summary>
		
		public object Params { get; set;}
		
		/// <summary>
		/// json-encoded parameters to pass into the action (If you use this, don't use Params)
		/// </summary>
		
		public string ParamsEncoded { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("ActionId", ActionId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Params", Params);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("ParamsEncoded", ParamsEncoded);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ActionId = (string)JsonUtil.Get<string>(json, "ActionId");
			Params = JsonUtil.GetObjectRaw(json, "Params");
			ParamsEncoded = (string)JsonUtil.Get<string>(json, "ParamsEncoded");
		}
	}
	
	
	
	public class RunCloudScriptResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// id of Cloud Script run
		/// </summary>
		
		public string ActionId { get; set;}
		
		/// <summary>
		/// version of Cloud Script run
		/// </summary>
		
		public int Version { get; set;}
		
		/// <summary>
		/// revision of Cloud Script run
		/// </summary>
		
		public int Revision { get; set;}
		
		/// <summary>
		/// return values from the server action as a dynamic object
		/// </summary>
		
		public object Results { get; set;}
		
		/// <summary>
		/// return values from the server action as a JSON encoded string
		/// </summary>
		
		public string ResultsEncoded { get; set;}
		
		/// <summary>
		/// any log statements generated during the run of this action
		/// </summary>
		
		public string ActionLog { get; set;}
		
		/// <summary>
		/// time this script took to run, in seconds
		/// </summary>
		
		public double ExecutionTime { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("ActionId", ActionId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Version", Version);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Revision", Revision);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Results", Results);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("ResultsEncoded", ResultsEncoded);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("ActionLog", ActionLog);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("ExecutionTime", ExecutionTime);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ActionId = (string)JsonUtil.Get<string>(json, "ActionId");
			Version = (int)JsonUtil.Get<double?>(json, "Version");
			Revision = (int)JsonUtil.Get<double?>(json, "Revision");
			Results = JsonUtil.GetObjectRaw(json, "Results");
			ResultsEncoded = (string)JsonUtil.Get<string>(json, "ResultsEncoded");
			ActionLog = (string)JsonUtil.Get<string>(json, "ActionLog");
			ExecutionTime = (double)JsonUtil.Get<double?>(json, "ExecutionTime");
		}
	}
	
	
	
	public class SendAccountRecoveryEmailRequest : PlayFabModelBase
	{
		
		
		
		public string Email { get; set;}
		
		
		public string TitleId { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("Email", Email);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("TitleId", TitleId);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Email = (string)JsonUtil.Get<string>(json, "Email");
			TitleId = (string)JsonUtil.Get<string>(json, "TitleId");
		}
	}
	
	
	
	public class SendAccountRecoveryEmailResult : PlayFabModelBase
	{
		
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class SetFriendTagsRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// PlayFab identifier of the friend account to which the tag(s) should be applied
		/// </summary>
		
		public string FriendPlayFabId { get; set;}
		
		/// <summary>
		/// array of tags to set on the friend account
		/// </summary>
		
		public List<string> Tags { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("FriendPlayFabId", FriendPlayFabId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Tags", Tags);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			FriendPlayFabId = (string)JsonUtil.Get<string>(json, "FriendPlayFabId");
			Tags = JsonUtil.GetList<string>(json, "Tags");
		}
	}
	
	
	
	public class SetFriendTagsResult : PlayFabModelBase
	{
		
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class SharedGroupDataRecord : PlayFabModelBase
	{
		
		
		/// <summary>
		/// data stored for the specified group data key
		/// </summary>
		
		public string Value { get; set;}
		
		/// <summary>
		/// PlayFabId of the user to last update this value
		/// </summary>
		
		public string LastUpdatedBy { get; set;}
		
		/// <summary>
		/// timestamp for when this data was last updated
		/// </summary>
		
		public DateTime LastUpdated { get; set;}
		
		/// <summary>
		/// indicates whether this data can be read by all users (public) or only members of the group (private)
		/// </summary>
		
		public UserDataPermission? Permission { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("Value", Value);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("LastUpdatedBy", LastUpdatedBy);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("LastUpdated", LastUpdated);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Permission", Permission);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Value = (string)JsonUtil.Get<string>(json, "Value");
			LastUpdatedBy = (string)JsonUtil.Get<string>(json, "LastUpdatedBy");
			LastUpdated = (DateTime)JsonUtil.GetDateTime(json, "LastUpdated");
			Permission = (UserDataPermission?)JsonUtil.GetEnum<UserDataPermission>(json, "Permission");
		}
	}
	
	
	
	public class StartGameRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// version information for the build of the game server which is to be started
		/// </summary>
		
		public string BuildVersion { get; set;}
		
		/// <summary>
		/// the region to associate this server with for match filtering
		/// </summary>
		
		public Region Region { get; set;}
		
		/// <summary>
		/// the title-defined game mode this server is to be running (defaults to 0 if there is only one mode)
		/// </summary>
		
		public string GameMode { get; set;}
		
		/// <summary>
		/// informs the service that a password is associated with this server
		/// </summary>
		
		public bool PasswordRestricted { get; set;}
		
		/// <summary>
		/// custom command line argument when starting game server process
		/// </summary>
		
		public string CustomCommandLineData { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("BuildVersion", BuildVersion);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Region", Region);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("GameMode", GameMode);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("PasswordRestricted", PasswordRestricted);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("CustomCommandLineData", CustomCommandLineData);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			BuildVersion = (string)JsonUtil.Get<string>(json, "BuildVersion");
			Region = (Region)JsonUtil.GetEnum<Region>(json, "Region");
			GameMode = (string)JsonUtil.Get<string>(json, "GameMode");
			PasswordRestricted = (bool)JsonUtil.Get<bool?>(json, "PasswordRestricted");
			CustomCommandLineData = (string)JsonUtil.Get<string>(json, "CustomCommandLineData");
		}
	}
	
	
	
	public class StartGameResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the lobby of the server started
		/// </summary>
		
		public string LobbyID { get; set;}
		
		/// <summary>
		/// server IP address
		/// </summary>
		
		public string ServerHostname { get; set;}
		
		/// <summary>
		/// port on the server to be used for communication
		/// </summary>
		
		public int? ServerPort { get; set;}
		
		/// <summary>
		/// unique identifier for the server
		/// </summary>
		
		public string Ticket { get; set;}
		
		/// <summary>
		/// timestamp for when the server should expire, if applicable
		/// </summary>
		
		public string Expires { get; set;}
		
		/// <summary>
		/// password required to log into the server
		/// </summary>
		
		public string Password { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("LobbyID", LobbyID);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("ServerHostname", ServerHostname);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("ServerPort", ServerPort);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Ticket", Ticket);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Expires", Expires);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Password", Password);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			LobbyID = (string)JsonUtil.Get<string>(json, "LobbyID");
			ServerHostname = (string)JsonUtil.Get<string>(json, "ServerHostname");
			ServerPort = (int?)JsonUtil.Get<double?>(json, "ServerPort");
			Ticket = (string)JsonUtil.Get<string>(json, "Ticket");
			Expires = (string)JsonUtil.Get<string>(json, "Expires");
			Password = (string)JsonUtil.Get<string>(json, "Password");
		}
	}
	
	
	
	public class StartPurchaseRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// catalog version for the items to be purchased. Defaults to most recent catalog.
		/// </summary>
		
		public string CatalogVersion { get; set;}
		
		/// <summary>
		/// store through which to purchase items. If not set, prices will be pulled from the catalog itself.
		/// </summary>
		
		public string StoreId { get; set;}
		
		/// <summary>
		/// the set of items to purchase
		/// </summary>
		
		public List<ItemPuchaseRequest> Items { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("CatalogVersion", CatalogVersion);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("StoreId", StoreId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Items", Items);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			CatalogVersion = (string)JsonUtil.Get<string>(json, "CatalogVersion");
			StoreId = (string)JsonUtil.Get<string>(json, "StoreId");
			Items = JsonUtil.GetObjectList<ItemPuchaseRequest>(json, "Items");
		}
	}
	
	
	
	public class StartPurchaseResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// purchase order identifier
		/// </summary>
		
		public string OrderId { get; set;}
		
		/// <summary>
		/// cart items to be purchased
		/// </summary>
		
		public List<CartItem> Contents { get; set;}
		
		/// <summary>
		/// available methods by which the user can pay
		/// </summary>
		
		public List<PaymentOption> PaymentOptions { get; set;}
		
		/// <summary>
		/// current virtual currency totals for the user
		/// </summary>
		
		public Dictionary<string,int> VirtualCurrencyBalances { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("OrderId", OrderId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Contents", Contents);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("PaymentOptions", PaymentOptions);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("VirtualCurrencyBalances", VirtualCurrencyBalances);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			OrderId = (string)JsonUtil.Get<string>(json, "OrderId");
			Contents = JsonUtil.GetObjectList<CartItem>(json, "Contents");
			PaymentOptions = JsonUtil.GetObjectList<PaymentOption>(json, "PaymentOptions");
			VirtualCurrencyBalances = JsonUtil.GetDictionaryInt32(json, "VirtualCurrencyBalances");
		}
	}
	
	
	
	/// <summary>
	/// A store entry that list a catalog item at a particular price
	/// </summary>
	public class StoreItem : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier of the item as it exists in the catalog - note that this must exactly match the ItemId from the catalog
		/// </summary>
		
		public string ItemId { get; set;}
		
		/// <summary>
		/// catalog version for this item
		/// </summary>
		
		public string CatalogVersion { get; set;}
		
		/// <summary>
		/// price of this item in virtual currencies and "RM" (the base Real Money purchase price, in USD pennies)
		/// </summary>
		
		public Dictionary<string,uint> VirtualCurrencyPrices { get; set;}
		
		/// <summary>
		/// override prices for this item for specific currencies
		/// </summary>
		
		public Dictionary<string,uint> RealCurrencyPrices { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("ItemId", ItemId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("CatalogVersion", CatalogVersion);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("VirtualCurrencyPrices", VirtualCurrencyPrices);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("RealCurrencyPrices", RealCurrencyPrices);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ItemId = (string)JsonUtil.Get<string>(json, "ItemId");
			CatalogVersion = (string)JsonUtil.Get<string>(json, "CatalogVersion");
			VirtualCurrencyPrices = JsonUtil.GetDictionaryUInt32(json, "VirtualCurrencyPrices");
			RealCurrencyPrices = JsonUtil.GetDictionaryUInt32(json, "RealCurrencyPrices");
		}
	}
	
	
	
	public class SubtractUserVirtualCurrencyRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// name of the virtual currency which is to be decremented
		/// </summary>
		
		public string VirtualCurrency { get; set;}
		
		/// <summary>
		/// amount to be subtracted from the user balance of the specified virtual currency
		/// </summary>
		
		public int Amount { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("VirtualCurrency", VirtualCurrency);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Amount", Amount);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			VirtualCurrency = (string)JsonUtil.Get<string>(json, "VirtualCurrency");
			Amount = (int)JsonUtil.Get<double?>(json, "Amount");
		}
	}
	
	
	
	public enum TitleActivationStatus
	{
		None,
		ActivatedTitleKey,
		PendingSteam,
		ActivatedSteam,
		RevokedSteam
	}
	
	
	
	public class TitleNewsItem : PlayFabModelBase
	{
		
		
		/// <summary>
		/// date and time when the news items was posted
		/// </summary>
		
		public DateTime Timestamp { get; set;}
		
		/// <summary>
		/// unique id of this bit of news
		/// </summary>
		
		public string NewsId { get; set;}
		
		/// <summary>
		/// title of the news item
		/// </summary>
		
		public string Title { get; set;}
		
		/// <summary>
		/// news item text
		/// </summary>
		
		public string Body { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("Timestamp", Timestamp);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("NewsId", NewsId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Title", Title);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Body", Body);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Timestamp = (DateTime)JsonUtil.GetDateTime(json, "Timestamp");
			NewsId = (string)JsonUtil.Get<string>(json, "NewsId");
			Title = (string)JsonUtil.Get<string>(json, "Title");
			Body = (string)JsonUtil.Get<string>(json, "Body");
		}
	}
	
	
	
	public enum TransactionStatus
	{
		CreateCart,
		Init,
		Approved,
		Succeeded,
		FailedByProvider,
		RefundPending,
		Refunded,
		RefundFailed,
		ChargedBack,
		FailedByUber,
		Revoked,
		TradePending,
		Upgraded,
		Other,
		Failed
	}
	
	
	
	public class UnlinkAndroidDeviceIDRequest : PlayFabModelBase
	{
		
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class UnlinkAndroidDeviceIDResult : PlayFabModelBase
	{
		
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class UnlinkFacebookAccountRequest : PlayFabModelBase
	{
		
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class UnlinkFacebookAccountResult : PlayFabModelBase
	{
		
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class UnlinkGameCenterAccountRequest : PlayFabModelBase
	{
		
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class UnlinkGameCenterAccountResult : PlayFabModelBase
	{
		
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class UnlinkIOSDeviceIDRequest : PlayFabModelBase
	{
		
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class UnlinkIOSDeviceIDResult : PlayFabModelBase
	{
		
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class UnlinkSteamAccountRequest : PlayFabModelBase
	{
		
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class UnlinkSteamAccountResult : PlayFabModelBase
	{
		
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class UnlockContainerItemRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier of the container to attempt to unlock
		/// </summary>
		
		public string ContainerItemId { get; set;}
		
		/// <summary>
		/// catalog version of the container
		/// </summary>
		
		public string CatalogVersion { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("ContainerItemId", ContainerItemId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("CatalogVersion", CatalogVersion);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ContainerItemId = (string)JsonUtil.Get<string>(json, "ContainerItemId");
			CatalogVersion = (string)JsonUtil.Get<string>(json, "CatalogVersion");
		}
	}
	
	
	
	public class UnlockContainerItemResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique instance identifier of the container unlocked
		/// </summary>
		
		public string UnlockedItemInstanceId { get; set;}
		
		/// <summary>
		/// unique instance identifier of the key used to unlock the container, if applicable
		/// </summary>
		
		public string UnlockedWithItemInstanceId { get; set;}
		
		/// <summary>
		/// items granted to the player as a result of unlocking the container
		/// </summary>
		
		public List<ItemInstance> GrantedItems { get; set;}
		
		/// <summary>
		/// virtual currency granted to the player as a result of unlocking the container
		/// </summary>
		
		public Dictionary<string,uint> VirtualCurrency { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("UnlockedItemInstanceId", UnlockedItemInstanceId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("UnlockedWithItemInstanceId", UnlockedWithItemInstanceId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("GrantedItems", GrantedItems);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("VirtualCurrency", VirtualCurrency);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			UnlockedItemInstanceId = (string)JsonUtil.Get<string>(json, "UnlockedItemInstanceId");
			UnlockedWithItemInstanceId = (string)JsonUtil.Get<string>(json, "UnlockedWithItemInstanceId");
			GrantedItems = JsonUtil.GetObjectList<ItemInstance>(json, "GrantedItems");
			VirtualCurrency = JsonUtil.GetDictionaryUInt32(json, "VirtualCurrency");
		}
	}
	
	
	
	public class UpdateEmailAddressRequest : PlayFabModelBase
	{
		
		
		
		public string Email { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("Email", Email);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Email = (string)JsonUtil.Get<string>(json, "Email");
		}
	}
	
	
	
	public class UpdateEmailAddressResult : PlayFabModelBase
	{
		
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class UpdateSharedGroupDataRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the shared group
		/// </summary>
		
		public string SharedGroupId { get; set;}
		
		/// <summary>
		/// key value pairs to be stored in the shared group - note that keys will be trimmed of whitespace, must not begin with a '!' character, and that null values will result in the removal of the key from the data set
		/// </summary>
		
		public Dictionary<string,string> Data { get; set;}
		
		/// <summary>
		/// permission to be applied to all user data keys in this request
		/// </summary>
		
		public UserDataPermission? Permission { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("SharedGroupId", SharedGroupId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Data", Data);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Permission", Permission);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			SharedGroupId = (string)JsonUtil.Get<string>(json, "SharedGroupId");
			Data = JsonUtil.GetDictionary<string>(json, "Data");
			Permission = (UserDataPermission?)JsonUtil.GetEnum<UserDataPermission>(json, "Permission");
		}
	}
	
	
	
	public class UpdateSharedGroupDataResult : PlayFabModelBase
	{
		
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class UpdateUserDataRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// data to be written to the user's custom data. A key with a null value will be removed, rather than being set to null.
		/// </summary>
		
		public Dictionary<string,string> Data { get; set;}
		
		/// <summary>
		/// Permission to be applied to all user data keys written in this request. Defaults to "private" if not set.
		/// </summary>
		
		public UserDataPermission? Permission { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("Data", Data);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Permission", Permission);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Data = JsonUtil.GetDictionary<string>(json, "Data");
			Permission = (UserDataPermission?)JsonUtil.GetEnum<UserDataPermission>(json, "Permission");
		}
	}
	
	
	
	public class UpdateUserDataResult : PlayFabModelBase
	{
		
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class UpdateUserStatisticsRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// statistics to be updated with the provided values
		/// </summary>
		
		public Dictionary<string,int> UserStatistics { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("UserStatistics", UserStatistics);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			UserStatistics = JsonUtil.GetDictionaryInt32(json, "UserStatistics");
		}
	}
	
	
	
	public class UpdateUserStatisticsResult : PlayFabModelBase
	{
		
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class UpdateUserTitleDisplayNameRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// new title display name for the user - must be between 3 and 25 characters
		/// </summary>
		
		public string DisplayName { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("DisplayName", DisplayName);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			DisplayName = (string)JsonUtil.Get<string>(json, "DisplayName");
		}
	}
	
	
	
	public class UpdateUserTitleDisplayNameResult : PlayFabModelBase
	{
		
		
		/// <summary>
		/// current title display name for the user (this will be the original display name if the rename attempt failed)
		/// </summary>
		
		public string DisplayName { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("DisplayName", DisplayName);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			DisplayName = (string)JsonUtil.Get<string>(json, "DisplayName");
		}
	}
	
	
	
	public class UserAccountInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// unique identifier for the user account
		/// </summary>
		
		public string PlayFabId { get; set;}
		
		/// <summary>
		/// timestamp indicating when the user account was created
		/// </summary>
		
		public DateTime Created { get; set;}
		
		/// <summary>
		/// user account name in the PlayFab service
		/// </summary>
		
		public string Username { get; set;}
		
		/// <summary>
		/// title-specific information for the user account
		/// </summary>
		
		public UserTitleInfo TitleInfo { get; set;}
		
		/// <summary>
		/// personal information for the user which is considered more sensitive
		/// </summary>
		
		public UserPrivateAccountInfo PrivateInfo { get; set;}
		
		/// <summary>
		/// user Facebook information, if a Facebook account has been linked
		/// </summary>
		
		public UserFacebookInfo FacebookInfo { get; set;}
		
		/// <summary>
		/// user Steam information, if a Steam account has been linked
		/// </summary>
		
		public UserSteamInfo SteamInfo { get; set;}
		
		/// <summary>
		/// user Gamecenter information, if a Gamecenter account has been linked
		/// </summary>
		
		public UserGameCenterInfo GameCenterInfo { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("PlayFabId", PlayFabId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Created", Created);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Username", Username);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("TitleInfo", TitleInfo);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("PrivateInfo", PrivateInfo);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("FacebookInfo", FacebookInfo);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("SteamInfo", SteamInfo);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("GameCenterInfo", GameCenterInfo);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			PlayFabId = (string)JsonUtil.Get<string>(json, "PlayFabId");
			Created = (DateTime)JsonUtil.GetDateTime(json, "Created");
			Username = (string)JsonUtil.Get<string>(json, "Username");
			TitleInfo = JsonUtil.GetObject<UserTitleInfo>(json, "TitleInfo");
			PrivateInfo = JsonUtil.GetObject<UserPrivateAccountInfo>(json, "PrivateInfo");
			FacebookInfo = JsonUtil.GetObject<UserFacebookInfo>(json, "FacebookInfo");
			SteamInfo = JsonUtil.GetObject<UserSteamInfo>(json, "SteamInfo");
			GameCenterInfo = JsonUtil.GetObject<UserGameCenterInfo>(json, "GameCenterInfo");
		}
	}
	
	
	
	public enum UserDataPermission
	{
		Private,
		Public
	}
	
	
	
	public class UserDataRecord : PlayFabModelBase
	{
		
		
		/// <summary>
		/// data stored for the specified user data key
		/// </summary>
		
		public string Value { get; set;}
		
		/// <summary>
		/// timestamp for when this data was last updated
		/// </summary>
		
		public DateTime LastUpdated { get; set;}
		
		/// <summary>
		/// indicates whether this data can be read by all users (public) or only the user (private)
		/// </summary>
		
		public UserDataPermission? Permission { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("Value", Value);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("LastUpdated", LastUpdated);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Permission", Permission);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Value = (string)JsonUtil.Get<string>(json, "Value");
			LastUpdated = (DateTime)JsonUtil.GetDateTime(json, "LastUpdated");
			Permission = (UserDataPermission?)JsonUtil.GetEnum<UserDataPermission>(json, "Permission");
		}
	}
	
	
	
	public class UserFacebookInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// Facebook identifier
		/// </summary>
		
		public string FacebookId { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("FacebookId", FacebookId);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			FacebookId = (string)JsonUtil.Get<string>(json, "FacebookId");
		}
	}
	
	
	
	public class UserGameCenterInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// Gamecenter identifier
		/// </summary>
		
		public string GameCenterId { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("GameCenterId", GameCenterId);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			GameCenterId = (string)JsonUtil.Get<string>(json, "GameCenterId");
		}
	}
	
	
	
	public enum UserOrigination
	{
		Organic,
		Steam,
		Google,
		Amazon,
		Facebook,
		Kongregate,
		GamersFirst,
		Unknown,
		IOS,
		LoadTest,
		Android,
		PSN,
		GameCenter
	}
	
	
	
	public class UserPrivateAccountInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// user email address
		/// </summary>
		
		public string Email { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("Email", Email);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			Email = (string)JsonUtil.Get<string>(json, "Email");
		}
	}
	
	
	
	public class UserSteamInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// Steam identifier
		/// </summary>
		
		public string SteamId { get; set;}
		
		/// <summary>
		/// the country in which the player resides, from Steam data
		/// </summary>
		
		public string SteamCountry { get; set;}
		
		/// <summary>
		/// currency type set in the user Steam account
		/// </summary>
		
		public Currency? SteamCurrency { get; set;}
		
		/// <summary>
		/// what stage of game ownership the user is listed as being in, from Steam
		/// </summary>
		
		public TitleActivationStatus? SteamActivationStatus { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("SteamId", SteamId);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("SteamCountry", SteamCountry);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("SteamCurrency", SteamCurrency);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("SteamActivationStatus", SteamActivationStatus);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			SteamId = (string)JsonUtil.Get<string>(json, "SteamId");
			SteamCountry = (string)JsonUtil.Get<string>(json, "SteamCountry");
			SteamCurrency = (Currency?)JsonUtil.GetEnum<Currency>(json, "SteamCurrency");
			SteamActivationStatus = (TitleActivationStatus?)JsonUtil.GetEnum<TitleActivationStatus>(json, "SteamActivationStatus");
		}
	}
	
	
	
	public class UserTitleInfo : PlayFabModelBase
	{
		
		
		/// <summary>
		/// name of the user, as it is displayed in-game
		/// </summary>
		
		public string DisplayName { get; set;}
		
		/// <summary>
		/// source by which the user first joined the game, if known
		/// </summary>
		
		public UserOrigination? Origination { get; set;}
		
		/// <summary>
		/// timestamp indicating when the user was first associated with this game (this can differ significantly from when the user first registered with PlayFab)
		/// </summary>
		
		public DateTime Created { get; set;}
		
		/// <summary>
		/// timestamp for the last user login for this title
		/// </summary>
		
		public DateTime? LastLogin { get; set;}
		
		/// <summary>
		/// timestamp indicating when the user first signed into this game (this can differ from the Created timestamp, as other events, such as issuing a beta key to the user, can associate the title to the user)
		/// </summary>
		
		public DateTime? FirstLogin { get; set;}
		
		/// <summary>
		/// boolean indicating whether or not the user is currently banned for a title
		/// </summary>
		
		public bool? isBanned { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("DisplayName", DisplayName);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Origination", Origination);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Created", Created);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("LastLogin", LastLogin);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("FirstLogin", FirstLogin);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("isBanned", isBanned);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			DisplayName = (string)JsonUtil.Get<string>(json, "DisplayName");
			Origination = (UserOrigination?)JsonUtil.GetEnum<UserOrigination>(json, "Origination");
			Created = (DateTime)JsonUtil.GetDateTime(json, "Created");
			LastLogin = (DateTime?)JsonUtil.GetDateTime(json, "LastLogin");
			FirstLogin = (DateTime?)JsonUtil.GetDateTime(json, "FirstLogin");
			isBanned = (bool?)JsonUtil.Get<bool?>(json, "isBanned");
		}
	}
	
	
	
	public class ValidateGooglePlayPurchaseRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// The original json string returned by the Google Play IAB api
		/// </summary>
		
		public string ReceiptJson { get; set;}
		
		/// <summary>
		/// The signature returned by the Google Play IAB api
		/// </summary>
		
		public string Signature { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("ReceiptJson", ReceiptJson);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("Signature", Signature);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ReceiptJson = (string)JsonUtil.Get<string>(json, "ReceiptJson");
			Signature = (string)JsonUtil.Get<string>(json, "Signature");
		}
	}
	
	
	
	public class ValidateGooglePlayPurchaseResult : PlayFabModelBase
	{
		
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
	
	
	public class ValidateIOSReceiptRequest : PlayFabModelBase
	{
		
		
		/// <summary>
		/// base64 encoded receipt data, passed back by the App Store as a result of a successful purchase
		/// </summary>
		
		public string ReceiptData { get; set;}
		
		/// <summary>
		/// currency used for the purchase
		/// </summary>
		
		public string CurrencyCode { get; set;}
		
		/// <summary>
		/// amount of the stated currency paid for the object
		/// </summary>
		
		public int PurchasePrice { get; set;}
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.WriteObjectProperty("ReceiptData", ReceiptData);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("CurrencyCode", CurrencyCode);
			
			writer.Writer.Write(JsonReader.OperatorValueDelim);
			
			writer.WriteObjectProperty("PurchasePrice", PurchasePrice);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
			ReceiptData = (string)JsonUtil.Get<string>(json, "ReceiptData");
			CurrencyCode = (string)JsonUtil.Get<string>(json, "CurrencyCode");
			PurchasePrice = (int)JsonUtil.Get<double?>(json, "PurchasePrice");
		}
	}
	
	
	
	public class ValidateIOSReceiptResult : PlayFabModelBase
	{
		
		
		public override void WriteJson(JsonWriter writer)
		{
			writer.Writer.Write(JsonReader.OperatorObjectStart);
			
			writer.Writer.Write(JsonReader.OperatorObjectEnd);
		}
		
		public override void Deserialize (Dictionary<string,object> json)
		{
			
		}
	}
	
}
