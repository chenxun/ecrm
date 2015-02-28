class TdUserResult < ActionWebService::Struct
	member :result,		:bool
	member :msg,		:string
	member :users,		[User]
end
