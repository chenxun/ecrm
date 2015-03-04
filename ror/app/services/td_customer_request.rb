class TdCustomerRequest < ActionWebService::Struct
	member :name,				:string
	member :user_id,			:int
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
	member :industry_type,		:string
	member :source,				:string
	member :rank_id,			:int
	member :area,				:string
	member :address,			:string
	member :remark,				:string
end
