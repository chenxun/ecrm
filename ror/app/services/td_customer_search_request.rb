class TdCustomerSearchRequest < ActionWebService::Struct
	member :name,				:string
	member :contact_man,		:string
	member :sales_id,			:int
	member :add_date_from,		:time
	member :add_date_to,		:time
end