class UserService < ActionWebService::Base
	web_service_api UserApi

	def add_user(user_request)
		user = User.new
		user.user_name = user_request.user_name
		user.password = user_request.password
		#user
		begin
			user.save
		rescue Exception => e
			return TdUserResult.new(:result => false, :msg => e, :users => nil)
		end
		TdUserResult.new :result => true, :msg => 'success', :users => [user]
	end

	def get_user_by_name(user_name)
		return TdUserResult.new(:result => false, :msg => 'user name must input', :users => nil) unless user_name
		#u = User.where("user_name=?", user_name)
		u = User.where(name: user_name).all
		return TdUserResult.new(:result => false, :msg => 'user not found', :users => nil) if u.blank?
		TdUserResult.new :result => true, :msg => 'user found', :users => u
	end
	def get_user_by_id(user_id)
		c = User.find(user_id)
		TdUserResult.new(:result => true, :msg => 'done', :users => [c])
	end
	def get_frames_by_user_id(user_id)
		user = User.includes(:roles).find(user_id)
		roles = user.roles
		return nil if roles.blank?
		frame_ids = []
		roles.each do |role|
			frames = role.frames
			frames.each do |frame|
				frame_ids << frame.id
			end
		end
		ret = Frame.order('rank').find(frame_ids)
	end
	def get_roles_by_user_id(user_id)
		user = User.includes(:roles).find(user_id)
		roles = user.roles
	end
	def get_roles_all
		roles = Role.order('name').all
	end
	def is_boss(soldier_id, manager_id)
		user = User.find(soldier_id)
		return find_manager(user, manager_id)
	end
	def find_manager(user, manager_id)
		if (user.manager_id.nil?)
			return false
		end
		if (user.manager.id == manager_id)
			return true
		end
		return find_manager(user.manager, manager_id)
	end
end
