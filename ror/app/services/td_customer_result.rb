class TdCustomerResult < ActionWebService::Struct
	member :result,		:bool
	member :msg,		:string
	member :customers,	[Customer]
end
