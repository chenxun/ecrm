class CustomerService < ActionWebService::Base
	web_service_api CustomerApi

	def add_customer(customer)
		c = User.new
		cus.user_name = 'xunchen'
		cus.save
		return Customer.first
	end
	def get_customer_by_id(customer_id)
		c = Customer.find([1,2])
		return TdCustomerResult.new(:result => true, :msg => '', :customers => c)
	end
	def get_visit_records_by_customer(customer_id)
		c = Customer.find(customer_id)
		records = c.visit_records
	end
end
