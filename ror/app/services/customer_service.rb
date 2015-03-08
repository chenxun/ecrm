class CustomerService < ActionWebService::Base
	web_service_api CustomerApi

	def add_customer(request)
		c = User.new
		request_to_customer(request, c)
		c.in_opensea = 0
		begin
			c.save
		rescue Exception => e
			return TdCustomerResult.new(:result => false, :msg => e, :customers => nil)
		end
		return TdCustomerResult.new(:result => true, :msg => nil, :customers => [c])
	end
	def get_customer_by_id(customer_id)
		begin
			c = Customer.find(customer_id)
		rescue Exception => e
			return TdCustomerResult.new(:result => false, :msg => e, :customers => nil)
		end
		return TdCustomerResult.new(:result => true, :msg => '', :customers => [c])
	end
	def get_visit_records_by_customer(customer_id)
		c = Customer.includes(:visit_records).find(customer_id)
		records = c.visit_records
	end
	def save_customer(request)
		begin
			c = Customer.find(request.id)
			request_to_customer(request, c)
			c.save
			# 当客户的负责人发生变化...
		rescue Exception => e
			return TdCustomerResult.new(:result => false, :msg => e, :customers => nil)
		end
		TdCustomerResult.new(:result => true, :msg => '', :customers => [c])
	end
	def customer_user_relation(customer_id, user_id)
		customer = Customer.find(customer_id)
		if (user_id == customer.user_id)
			return 1
		end
		if find_manager(customer.user, user_id)
			return 2
		end
		return 0
		#customer.user.manager.id
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
	def request_to_customer(request, customer)
		customer.name = request.name
		customer.user_id = request.user_id
		customer.web_site = request.web_site
		customer.contact_man = request.contact_man
		customer.qq = request.qq
		customer.tel = request.tel
		customer.ext = request.ext
		customer.mobile = request.mobile
		customer.fax = request.fax
		customer.email = request.email
		customer.position = request.position
		customer.buy_intent = request.buy_intent
		customer.source = request.source
		customer.industry_type = request.industry_type
		customer.rank_id = request.rank_id
		customer.area = request.area
		customer.address = request.address
		customer.remark = request.remark
		customer.keywords = request.keywords
	end
end
