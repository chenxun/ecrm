class UserService < ActionWebService::Base
	web_service_api UserApi

	def add_user(user_request)
		new_user = user_request[:user]
		res = User.new(new_user)
		res.save
		TdUserResult.new :result => true, :msg => res.id, :user => res
	end
end
