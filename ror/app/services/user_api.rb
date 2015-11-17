class UserApi < ActionWebService::API::Base
	# user api
	api_method :add_user, :expects => [{:user_request=>TdUserRequest}], :returns => [TdUserResult]
	api_method :save_user, :expects => [{:user_request=>TdUserRequest}], :returns => [TdUserResult]
	api_method :get_user_by_name, :expects => [{:user_name=>:string}], :returns => [TdUserResult]
	api_method :get_user_by_id, :expects => [{:user_id => :int}], :returns => [TdUserResult]
	api_method :get_soldiers, :expects => [{:manager_id=>:int}], :returns => [TdUserResult]
	api_method :is_boss, :expects => [{:soldier_id=>:int},{:manager_id=>:int}], :returns => [:bool]
	# role api
	api_method :get_frames_by_user, :expects => [{:user_id => :int}], :returns => [TdFrameResult]
	api_method :get_roles_by_user, :expects => [{:user_id => :int}], :returns => [[Role]]
	api_method :set_user_roles, :expects => [{:user_id=>:int},{:roles=>[:int]}], :returns => [:int]
	api_method :get_roles_all, :expects => [], :returns => [[Role]]
	# department api
	api_method :add_department, :expects => [{:name=>:string}], :returns => [Department]
	#api_method :get_persons_all, :expects => [], :returns => [[Person]]
end
