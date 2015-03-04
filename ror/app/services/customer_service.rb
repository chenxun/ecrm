class CustomerService < ActionWebService::Base
	web_service_api CustomerApi

	def add_customer(request)
		c = User.new
		c.name = request.name
		c.user_id = request.user_id
		c.web_site = request.web_site
		c.contact_man = request.contact_man
		c.qq = request.qq
		c.tel = request.tel
		c.ext = request.ext
		c.mobile = request.mobile
		c.fax = request.fax
		c.email = request.email
		c.position = request.position
		c.buy_intent = request.buy_intent
		c.source = request.source
		c.industry_type = request.industry_type
		c.rank_id = request.rank_id
		c.area = request.area
		c.address = request.address
		c.remark = request.remark
		c.keywords = request.keywords
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
end
