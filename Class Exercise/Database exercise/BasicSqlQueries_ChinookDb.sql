-- 1. list all customers (full names, customer ID, and country) who
--are not in the US
select * from Customer
where customer.country!='USA'

-- 2. list all customers from brazil
select * from Customer
where customer.country='Brazil'

-- 3. list all sales agents
select * from Employee
where Employee.Title = 'Sales Support Agent'

-- 4. show a list of all countries in billing addresses on invoices.
select distinct BillingCountry from invoice

-- 5. How many invoices were there in 2009, and what was the sales total for that year?
select count(Invoice.InvoiceId), sum(Invoice.Total) from invoice

-- 6. How many line items were there for invoice #37?
select count(invoicelineid) from invoiceline
where invoiceid = 37

-- 7. How many invoices per country?

select BillingCountry, count(BillingCountry) from invoice
group by(BillingCountry)
         

-- 8. Show total sales per country, ordered by highest sales first
select billingcountry, sum(total) from invoice
group by BillingCountry
order by sum(total) DESC