class TdCustomerRequest < ActionWebService::Struct
	member :name,				:string
	member :web_site,			:string
	member :contact_man,		:string
	member :qq,					:string
	member :tel,				:string
	member :ext,				:string
	member :mobile,				:string
	member :fax,				:string
	member :email,				:string
	member :position,			:string
	member :keywords,			:string
	member :buy_intent,			:string
	member :visit_type,			:string
	member :rank,				:int
	member :area,				:int
	member :address,			:string
end
