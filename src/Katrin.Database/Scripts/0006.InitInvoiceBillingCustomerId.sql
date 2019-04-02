
update Invoice set BillingCustomerId=(select top 1 BillingCustomerId from  dbo.Contract where ContractId in 
( select ContractId from dbo.InvoiceContract where InvoiceId = Invoice.InvoiceId)) 
