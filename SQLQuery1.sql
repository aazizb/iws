update settlement set IsValidated=0
update Payment  set IsValidated=0
update GeneralLedger  set IsValidated=0
update CustomerInvoice set IsValidated=0
update VendorInvoice set IsValidated=0
update SalesInvoice set IsValidated=0
update InventoryInvoice set IsValidated=0
update BillOfDelivery set IsValidated=0
update GoodReceiving set IsValidated=0
update SalesOrder set IsValidated=0
update PurchaseOrder set IsValidated=0
update Account set balance=0 where balance<>0
delete from PeriodicAccountBalance
