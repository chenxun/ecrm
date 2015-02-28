class TdCustomerSearchRequest < ActionWebService::Struct
	member :name,			:string
	member :contact_man		:string
	member :sales_id		:int
	member :add_date_from	:date
	member :add_date_to		:date
end